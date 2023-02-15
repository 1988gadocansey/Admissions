using OnlineApplicationSystem.Application.Biodata.Queries;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicantRepository
{
    
    public Task<ApplicantDto> GetApplicant(int Id, CancellationToken cancellationToken);
    public Task<int> SendFileToServer(string host, int port, string username, string password, string filePath);
    public Task SendSMSNotification(string PhoneNumber, string Message);
    public Task SendEmailNotification(string Email, string Message);
    public Task<bool> ContainsDuplicates(int[] data);
    public Task<int> GetAge(DateTime dateOfBirth);
    public Task<bool> QualifiesMature(int age);
    public Task<int> checkFailed(IEnumerable<int> GradeValues);
    public Task<int> checkPassed(IEnumerable<int> GradeValues);
    public Task<string[]> GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives);
    public Task<int> GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives);
    public Task<string> GetFormNo();
    public Task<int> UpdateFormNo(CancellationToken cancellationToken);

    public Task<ConfigurationModel?> GetConfiguration();
}