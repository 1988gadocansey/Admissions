namespace CleanArchitecture.Infrastructure.Services.Mails;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
