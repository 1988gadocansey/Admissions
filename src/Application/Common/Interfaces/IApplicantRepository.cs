using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicantRepository
{

    public Task<ApplicantVm> GetApplicantForUser(string Id, CancellationToken cancellationToken);
    public Task<ApplicantVm> GetApplicant(int Id, CancellationToken cancellationToken);
    // public Task<bool> SendSMSNotification(string phoneNumber, string message, long formNo, string appSender);
    // public Task SendEmailNotification(string Email, string Message);
    public Task<bool> ContainsDuplicates(IEnumerable<int> data);
    public Task<int> GetAge(DateOnly dateOfBirth);
    public Task<bool> QualifiesMature(int age);
    public int CheckFailed(IEnumerable<int> gradeValues);
    public int CheckPassed(IEnumerable<int> GradeValues);
    public Task<IEnumerable<string>> GradesIssues(IEnumerable<int> Cores, IEnumerable<int> CoreAlt, IEnumerable<int> Electives);
    public Task<int> GetTotalAggregate(IEnumerable<int> Cores, IEnumerable<int> CoreAlt, IEnumerable<int> Electives);
    public Task<string> GetFormNo();
    public Task<int> UpdateFormNo(CancellationToken cancellationToken);
    public Task<IEnumerable<ReligionDto>> Religions(CancellationToken cancellationToken);
    public Task<IEnumerable<CountryDto>> Countries(CancellationToken cancellationToken);
    public Task<IEnumerable<RegionDto>> Regions(CancellationToken cancellationToken);
    public Task<IEnumerable<DistrictDto>> Districts(CancellationToken cancellationToken);
    public Task<IEnumerable<DenominationDto>> Denominations(CancellationToken cancellationToken);
    public Task<IEnumerable<HallDto>> Halls(CancellationToken cancellationToken);
    public Task<IEnumerable<ExamDto>> Exams(CancellationToken cancellationToken);
    public Task<IEnumerable<FormerSchoolDto>> Schools(CancellationToken cancellationToken);
    public Task<IEnumerable<ProgrammeDto>> Programmes(string FormType);
    public Task<IEnumerable<SubjectDto>> Subjects(CancellationToken cancellationToken);
    public Task<IEnumerable<GradeDto>> Grades(CancellationToken cancellationToken);

    public Task<IEnumerable<LanguageDto>> Languages(CancellationToken cancellationToken);
    public Task<IEnumerable<DisabilitiesDto>> Disabilities(CancellationToken cancellationToken);
    public Task<IEnumerable<SHSProgrammesDto>> SHSProgrammes(CancellationToken cancellationToken);
    public Task<IEnumerable<UniversityAttendedDto>> UniversityAttended(CancellationToken cancellationToken);
    public Task<IEnumerable<SHSAttendedDto>> SHSAttendeds(CancellationToken cancellationToken);
    public Task<ConfigurationModel?> GetConfiguration();

    public Task<ApplicantVm> GetApplicantByApplicationNumber(long ApplicationNumber, CancellationToken cancellationToken);

}