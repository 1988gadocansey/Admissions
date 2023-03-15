using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Preview.Commands;
using OnlineApplicationSystem.Infrastructure.Common;

namespace OnlineApplicationSystem.Infrastructure.Mails;

public class EmailService : IEmailSender
{
    private MailSettings _mailSettings { get; }
    private readonly IApplicantRepository _applicantRepository;

    public EmailService(IOptions<MailSettings> mailSettings, IApplicantRepository applicantRepository)
    {
        _mailSettings = mailSettings.Value;
        _applicantRepository = applicantRepository;
    }
    public async Task SendEmail(string? To, string? Subject, string? Body, string? From)
    {
        try
        {
            // create message
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, From ?? _mailSettings.EmailFrom);
            email.To.Add(MailboxAddress.Parse(To));
            email.Subject = Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = Body;
            using var smtp = new SmtpClient();
            email.Body = builder.ToMessageBody();
            smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
        catch (System.Exception ex)
        {

        }

    }
}
