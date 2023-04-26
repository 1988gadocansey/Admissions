using System.Net.Http.Headers;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
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
    public async Task SendSms(string phoneNumber, string message, long formNo, string appSender, CancellationToken cancellationToken = default(CancellationToken))
    {
        var applicant = _applicantRepository.GetApplicantByApplicationNumber(formNo, cancellationToken);

        var _URL = "https://smsc.hubtel.com/v1/messages/send?";

        var _senderid = "TTU"; // here assigning sender id 


        var _user = HttpUtility.UrlEncode("ifrzlixd"); // API user name to send SMS
        var _pass = "zrydysvw"; // API password to send SMS


        phoneNumber = "+233" + phoneNumber.Substring(1, 9);


        phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");


        var _recipient = phoneNumber; // who will receive message

        var _messageText = HttpUtility.UrlEncode(message); // text message

        var result = "";

        // Creating URL to send sms
        string _createURL = _URL +
                            "clientid=" + _user +
                            "&clientsecret=" + _pass +
                            "&from=" + _senderid +
                            "&to=" + _recipient +
                            "&content=" + _messageText;

        Console.WriteLine("url" + _createURL);

        try
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
            result = http.GetAsync(_createURL).Result.Content.ReadAsStringAsync().Result;

            var jsonResult = JsonConvert.DeserializeObject(result).ToString();
            var response = JsonConvert.DeserializeObject<SMSResponse>(jsonResult);
            Console.WriteLine("response is .." + response.status);
            if (response.status == 0)
            {
                var sms = new SMSModel { Recipient = formNo, DateSent = DateTime.UtcNow, Message = message, SentBy = appSender, Status = response.status == 0 ? "successful" : "failed", ApplicantModelID = applicant.Id };
                await _context.SMSModels.AddAsync(sms);
                await _context.SaveChangesAsync(cancellationToken);

            }
            //Console.WriteLine("result is " + result);
            // creating web request to send sms 
        }

        catch (Exception e)
        {
            Console.WriteLine(e.ToString());

        }

    }
}
