using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicantRepository
{
    public Task<IEnumerable<ApplicantModel>> GetResults(ApplicantModel applicant, CancellationToken cancellationToken);
    public Task<string> GetProgrammeName(int id);

    public Task<ApplicantModel> GetApplicantIdFromFormNo(string id);

    public Task<string> GetApplicantCodeFromId(int id);

    public Task<string> GetHallName(int hall);

    public Task<double> GetHallFee(int hall);

    public Task<int> SendFileToServer(string host, int port, string username, string password, string filePath);

    public Task SendSMSNotification(string PhoneNumber, string Message);

    public Task SendEmailNotification(string Email, string Message);

    public Task<bool> ContainsDuplicates(int[] a);
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