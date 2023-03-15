using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Preview.Commands;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Infrastructure.Common;
using RestSharp;

namespace OnlineApplicationSystem.Infrastructure.SMS;

public class SmsService : ISmsSender
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly RestClient _client;
    public SmsService(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;
    }
    public async Task SendSms(string phoneNumber, string message, long formNo, string appSender)
    {

        const string senderid = "TTU";
        const string apiKey = "USCULtE3m0afDH2cflug17HZSV4qiiOcaq7WTMZgN9vqR"; // API password to send SMS
        phoneNumber = "+233" + phoneNumber.Substring(1, 9);
        phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");
        var messageText = HttpUtility.UrlEncode(message); // text message
        const string url = "https://api.mnotify.com/api/sms/quick?key=" + apiKey;
        try
        {
            var clientRequest =
                new RestRequest(url).AddJsonBody(new
                {
                    recipient = phoneNumber,
                    sender = senderid,
                    message = messageText,
                    is_schedule = false,
                    schedule_date = ""
                });
            var smsResponse = await _client.PostAsync(clientRequest);
            if (smsResponse.IsSuccessful)
            {
                var sms = new SMSModel { Recipient = Convert.ToInt16(formNo), DateSent = DateTime.UtcNow, Message = messageText, SentBy = appSender, Status = Convert.ToString(smsResponse.IsSuccessful) };
                _context.SMSModels.AddAsync(sms);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

        }

    }
}
