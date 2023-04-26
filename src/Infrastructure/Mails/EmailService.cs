using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Infrastructure.Common;


namespace OnlineApplicationSystem.Infrastructure.Mails;

public class EmailService : IEmailSender
{
    private readonly MailSettings _settings;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IConfiguration _configuration;
    public EmailService(IOptions<MailSettings> mailSettings, IApplicantRepository applicantRepository, IConfiguration configuration)
    {
        _settings = mailSettings.Value;
        _applicantRepository = applicantRepository;
        _configuration = configuration;
    }
    public async Task SendEmail(string? To, string? Subject, string? Body, string? From)
    {
        // var emailSettings = _configuration.GetValue<string>("EmailConfiguration");
        // create message
        var email = new MimeMessage();
        email.Sender = new MailboxAddress("TTU Admissions", "gadocansey@gmail.com");
        email.To.Add(MailboxAddress.Parse(To));
        email.Subject = Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = Body;
        using var smtp = new SmtpClient();
        email.Body = builder.ToMessageBody();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("gadocansey@gmail.com", "jzpgrzmrnwkbknkd");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);


    }
    public async Task<bool> SendAsync(MailData mailData, CancellationToken ct = default)
    {
        try
        {
            // Initialize a new instance of the MimeKit.MimeMessage class
            var mail = new MimeMessage();

            #region Sender / Receiver
            // Sender
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

            // Receiver
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Set Reply to if specified in mail data
            if (!string.IsNullOrEmpty(mailData.ReplyTo))
                mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

            // BCC
            // Check if a BCC was supplied in the request
            if (mailData.Bcc != null)
            {
                // Get only addresses where value is not null or with whitespace. x = value of address
                foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }

            // CC
            // Check if a CC address was supplied in the request
            if (mailData.Cc != null)
            {
                foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }
            #endregion

            #region Content

            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = mailData.Body;
            mail.Body = body.ToMessageBody();

            #endregion

            #region Send Mail

            using var smtp = new SmtpClient();

            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (_settings.UseStartTls)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
            }

            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
            await smtp.SendAsync(mail, ct);
            await smtp.DisconnectAsync(true, ct);

            return true;
            #endregion

        }
        catch (Exception)
        {
            return false;
        }
    }

    /*  public async Task<bool> SendWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken ct = default)
      {
          try
          {
              // Initialize a new instance of the MimeKit.MimeMessage class
              var mail = new MimeMessage();

              #region Sender / Receiver
              // Sender
              mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
              mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

              // Receiver
              foreach (string mailAddress in mailData.To)
                  mail.To.Add(MailboxAddress.Parse(mailAddress));

              // Set Reply to if specified in mail data
              if (!string.IsNullOrEmpty(mailData.ReplyTo))
                  mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

              // BCC
              // Check if a BCC was supplied in the request
              if (mailData.Bcc != null)
              {
                  // Get only addresses where value is not null or with whitespace. x = value of address
                  foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                      mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
              }

              // CC
              // Check if a CC address was supplied in the request
              if (mailData.Cc != null)
              {
                  foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                      mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
              }
              #endregion

              #region Content

              // Add Content to Mime Message
              var body = new BodyBuilder();
              mail.Subject = mailData.Subject;

              // Check if we got any attachments and add the to the builder for our message
              if (mailData.Attachments != null)
              {
                  byte[] attachmentFileByteArray;
                  foreach (IFormFile attachment in mailData.Attachments)
                  {
                      if (attachment.Length > 0)
                      {
                          using (MemoryStream memoryStream = new MemoryStream())
                          {
                              attachment.CopyTo(memoryStream);
                              attachmentFileByteArray = memoryStream.ToArray();
                          }
                          body.Attachments.Add(attachment.FileName, attachmentFileByteArray, ContentType.Parse(attachment.ContentType));
                      }
                  }
              }
              body.HtmlBody = mailData.Body;
              mail.Body = body.ToMessageBody();

              #endregion

              #region Send Mail

              using var smtp = new SmtpClient();

              if (_settings.UseSSL)
              {
                  await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
              }
              else if (_settings.UseStartTls)
              {
                  await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
              }

              await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
              await smtp.SendAsync(mail, ct);
              await smtp.DisconnectAsync(true, ct);

              return true;
              #endregion

          }
          catch (Exception)
          {
              return false;
          }
      }
       public string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel)
      {
          string mailTemplate = LoadTemplate(emailTemplate);

          IRazorEngine razorEngine = new RazorEngine();
          IRazorEngineCompiledTemplate modifiedMailTemplate = razorEngine.Compile(mailTemplate);

          return modifiedMailTemplate.Run(emailTemplateModel);
      }

      public string LoadTemplate(string emailTemplate)
      {
          string baseDir = AppDomain.CurrentDomain.BaseDirectory;
          string templateDir = Path.Combine(baseDir, "Files/MailTemplates");
          string templatePath = Path.Combine(templateDir, $"{emailTemplate}.cshtml");
          using FileStream fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          using StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
          string mailTemplate = streamReader.ReadToEnd();
          streamReader.Close();

          return mailTemplate;
      } */


}
