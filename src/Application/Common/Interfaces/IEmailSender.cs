using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IEmailSender
{
    Task SendEmail(string? To, string? Subject, string? Body, string? From);
    Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    // Task<bool> SendWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken ct);
    //string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel);
}