

namespace OnlineApplicationSystem.Domain.Contracts;

public interface IHelper
{
    public string GetProgrammeName(int id);

    public ApplicantModel GetApplicantIdFromFormNo(string id);

    public string GetApplicantCodeFromId(int id);

    public string GetHallName(int hall);

    public double GetHallFee(int hall);

    public int SendFileToServer(string host, int port, string username, string password, string filePath);

    public string SendSMSNotification(string PhoneNumber, string Message);

    public void SendEmailNotification(string Email, string Message);

    public bool ContainsDuplicates(int[] a);
    public int GetAge(DateTime dateOfBirth);

    public bool QualifiesMature(int age);
    public int checkFailed(IEnumerable<int> GradeValues);

    public int checkPassed(IEnumerable<int> GradeValues);

    public string[] GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives);

    public int GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives);

    public string GetFormNo();
    public Task<int> UpdateFormNo();

    public ConfigurationModel? GetConfiguration();
}