using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using OnlineApplicationSystem.Domain.Contracts;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Infrastructure.Persistence;
using Renci.SshNet;

namespace OnlineApplicationSystem.Infrastructure.Services;

public class HelperService : IHelper
{
    private readonly ApplicationDbContext _dbContext;

    public HelperService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string GetProgrammeName(int id)
    {
        var programme = _dbContext.ProgrammeModel.First(p => p.Id == id);

        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(programme.Name);
    }

    public string GetApplicantCodeFromId(int id)
    {
        var programme = _dbContext.ProgrammeModel.First(p => p.Id == id);

        return programme.Code;
    }

    public double GetHallFee(int hall)
    {
        var hallData = _dbContext.HallModel.First(p => p.Id == hall);

        return hallData.Fees;
    }

    public string GetHallName(int hall)
    {
        var hallData = _dbContext.HallModel.First(p => p.Id == hall);

        return hallData.Name;
    }


    public int SendFileToServer(string host, int port, string username, string password, string uploadFile)
    {
        using var client = new SftpClient(host, port, username, password);
        client.Connect();
        if (client.IsConnected)
        {
            Debug.WriteLine("I'm connected to the client");
            client.ChangeDirectory("/var/www/html/photos/public/albums/thumbnails");
            using (var fileStream = new FileStream(uploadFile, FileMode.Open))
            {
                client.BufferSize = 4 * 1024; // bypass Payload error large files
                client.UploadFile(fileStream, Path.GetFileName(uploadFile));
            }

            return 1;
        }
        else
        {
            Debug.WriteLine("I couldn't connect");
            return 0;
        }
    }


    void IHelper.SendEmailNotification(string Email, string Message)
    {
        // Command-line argument must be the SMTP host.
        SmtpClient client = new SmtpClient("smtp.google.com");

        client.EnableSsl = true;

        var NetworkCred = new NetworkCredential("gadocansey@gmail.com", "031988gadocansey");
        client.UseDefaultCredentials = true;
        client.Credentials = NetworkCred;
        client.Port = 587;
        // Specify the email sender.
        // Create a mailing address that includes a UTF8 character
        // in the display name.
        var from = new MailAddress("admissions@ttu.edu.gh",
            "Admissions " + (char)0xD8 + " TTU",
            System.Text.Encoding.UTF8);

        // Set destinations for the email message.
        MailAddress to = new MailAddress(Email);
        // Specify the message content.
        MailMessage message = new MailMessage(from, to);
        message.Body = Message;
        // Include some non-ASCII characters in body and subject.
        var someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
        message.Body += Environment.NewLine + someArrows;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Subject = "From Admissions - Takoradi Technical University" + someArrows;
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        const string userState = "TTU Admissions";
        // Set the method that is called back when the send operation ends.
        client.SendAsync(message, userState);

        // Clean up.
        message.Dispose();
    }


    public string SendSMSNotification(string PhoneNumber, string Message)
    {
        var _URL = "https://smsc.hubtel.com/v1/messages/send?";

        var _senderid = "TTU"; // here assigning sender id 

        var _user = HttpUtility.UrlEncode("ifrzlixd"); // API user name to send SMS
        var _pass = "zrydysvw"; // API password to send SMS


        PhoneNumber = "+233" + PhoneNumber.Substring(1, 9);


        PhoneNumber = PhoneNumber.Replace(" ", "").Replace("-", "");


        var _recipient = PhoneNumber; // who will receive message

        var _messageText = HttpUtility.UrlEncode(Message); // text message

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

            Console.WriteLine("result is " + result);
            // creating web request to send sms 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString()); //
        }

        return result;
    }

    bool IHelper.ContainsDuplicates(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] == a[j]) return true;
            }
        }

        return false;
    }

    public ApplicantModel GetApplicantIdFromFormNo(string id)
    {

        var applicant = _dbContext.ApplicantModel.FirstOrDefault(p => p.Id.ToString() == id);

        return applicant;
    }

    public int GetAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (a - b) / 10000;
    }

    public bool QualifiesMature(int age)
    {
        return age >= 25;
    }

    public int checkPassed(IEnumerable<int> GradeValues)
    {
        return GradeValues.Count(values => values <= 7);
    }

    public int checkFailed(IEnumerable<int> GradeValues)
    {
        return GradeValues.Count(values => values > 7);
    }

    public string[] GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        var error = new string[4];
        if (Cores.Length + CoreAlt.Length + Electives.Length != 6)
        {
            const string msg = "Results not completed.";
            Array.Fill(error, msg);
        }
        else if (Cores.Length < 2)
        {
            const string msg = "Minimum of two(2) core subjects not met.";
            Array.Fill(error, msg);
        }
        else if (Electives.Length < 3)
        {
            const string msg = "Minimum of three(3) elective subjects not met.";
            Array.Fill(error, msg);
        }
        else if (!CoreAlt.Any())
        {
            const string msg = "Social or Science required.";
            Array.Fill(error, msg);
        }
        else
        {
            string msg = null;
            Array.Fill(error, msg);
        }

        return error;
    }
    public int GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        IEnumerable<int> sliceCoreAlt = CoreAlt.AsQueryable().OrderBy(s => s).Take(1);
        IEnumerable<int> sliceElective = CoreAlt.AsQueryable().OrderBy(s => s).Take(3);
        var grade = Cores.Sum() + sliceElective.Sum() + sliceCoreAlt.Sum();
        return grade;
    }
    public string GetFormNo()
    {
        var configuration = _dbContext.ConfigurationModel.OrderByDescending(b => b.Id).FirstOrDefault();
        var formNumber = _dbContext.FormNoModel.First(n => n.Year == configuration.Year);
        return formNumber.No.ToString();
    }
    public async Task<int> UpdateFormNo()
    {
        var configuration = _dbContext.ConfigurationModel.OrderByDescending(b => b.Id).FirstOrDefault();
        var update = _dbContext.FormNoModel.First(n => n.Year == configuration.Year);
        update.No += 1;
        return await _dbContext.SaveChangesAsync();
    }

    public ConfigurationModel? GetConfiguration()
    {
        var configuration = _dbContext.ConfigurationModel.OrderByDescending(b => b.Id).FirstOrDefault();
        return configuration;
    }
}