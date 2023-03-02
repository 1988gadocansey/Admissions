using OnlineApplicationSystem.Application.Biodata.Queries;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicantRepository
{

    public Task<ApplicantDto> GetApplicant(int Id, CancellationToken cancellationToken);
    //public Task<int> SendFileToServer(string host, int port, string username, string password, string filePath);
    Task SendSMSNotification(string PhoneNumber, string Message);
    Task SendEmailNotification(string Email, string Message);
    Task<bool> ContainsDuplicates(int[] data);
    Task<int> GetAge(DateOnly dateOfBirth);
    Task<bool> QualifiesMature(int age);
    Task<int> checkFailed(IEnumerable<int> GradeValues);
    Task<int> checkPassed(IEnumerable<int> GradeValues);
    Task<string[]> GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives);
    Task<int> GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives);
    Task<string> GetFormNo();
    Task<int> UpdateFormNo(CancellationToken cancellationToken);
    public Task<IEnumerable<ReligionDto>> Religions(CancellationToken cancellationToken);
    public Task<CountryModel> Countries(CancellationToken cancellationToken);
    public Task<RegionModel> Regions(CancellationToken cancellationToken);
    public Task<DistrictModel> Districts(CancellationToken cancellationToken);
    public Task<DenominationModel> Denominations(CancellationToken cancellationToken);
    public Task<HallModel> Halls(CancellationToken cancellationToken);
    public Task<ExamModel> Exams(CancellationToken cancellationToken);
    public Task<FormerSchoolModel> Schools(CancellationToken cancellationToken);
    public ProgrammeModel Programmes(string FormType);
    public Task<SubjectModel> Subjects(CancellationToken cancellationToken);
    public Task<ConfigurationModel?> GetConfiguration();

}