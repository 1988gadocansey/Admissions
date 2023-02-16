using System.Net;
using System.Net.Mail;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Biodata.Queries;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ApplicantRepository(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    Task<int> IApplicantRepository.checkFailed(IEnumerable<int> GradeValues)
    {
        throw new NotImplementedException();
    }

    Task<int> IApplicantRepository.checkPassed(IEnumerable<int> GradeValues)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ContainsDuplicates(int[] results)
    {
        /* var duplicates = results.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList(); */
        if (results.Length != results.Distinct().Count())
        {
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    public Task<int> GetAge(DateOnly dateOfBirth)
    {
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        var age = (a - b) / 10000;
        return Task.FromResult(age);
    }

    public async Task<ApplicantDto> GetApplicant(int Id, CancellationToken cancellationToken)
    {
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.Id == Id, cancellationToken);
        /*var applicantDto = new ApplicantDto()
        {
            FirstName = applicant.ApplicantName.FirstName,
            LastName = applicant.ApplicantName.LastName,
            Gender = applicant.Gender,
            OtherName = applicant.ApplicantName.Othernames,
            Title = applicant.Title,
            Dob = applicant.Dob,
            MaritalStatus = applicant.MaritalStatus,
        };*/
        var applicantDetails = _mapper.Map<ApplicantDto>(applicant);
        return applicantDetails;
    }

    Task<ConfigurationModel?> IApplicantRepository.GetConfiguration()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetFormNo()
    {
        var configuration = _context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefault();
        var formNumber = _context.FormNoModels.First(n => n.Year == configuration.Year);
        return formNumber.No.ToString();
    }

    Task<int> IApplicantRepository.GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        throw new NotImplementedException();
    }

    Task<string[]> IApplicantRepository.GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        throw new NotImplementedException();
    }

    Task<bool> IApplicantRepository.QualifiesMature(int age)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailNotification(string Email, string Message)
    {
        var client = new SmtpClient("smtp.google.com");
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
        var to = new MailAddress(Email);
        // Specify the message content.
        var message = new MailMessage(from, to);
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
        return Task.CompletedTask;
    }



    Task IApplicantRepository.SendSMSNotification(string PhoneNumber, string Message)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateFormNo(CancellationToken cancellationToken)
    {
        var configuration = _context.ConfigurationModels.OrderByDescending(b => b.Id).FirstOrDefault();
        var update = _context.FormNoModels.First(n => n.Year == configuration.Year);
        update.No += 1;
        return await _context.SaveChangesAsync(cancellationToken);
    }
}