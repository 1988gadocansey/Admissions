using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicantRepository
{

    public Task<ApplicantDto> GetApplicant(int Id, CancellationToken cancellationToken);
    public Task SendSMSNotification(string PhoneNumber, string Message);
    public Task SendEmailNotification(string Email, string Message);
    public Task<bool> ContainsDuplicates(int[] data);
    public Task<int> GetAge(DateOnly dateOfBirth);
    public Task<bool> QualifiesMature(int age);
    public Task<int> checkFailed(IEnumerable<int> GradeValues);
    public Task<int> checkPassed(IEnumerable<int> GradeValues);
    public Task<string[]> GradesIssues(IEnumerable<GradeModel> Cores, IEnumerable<GradeModel> CoreAlt, IEnumerable<GradeModel> Electives);
    public Task<int> GetTotalAggregate(IEnumerable<GradeModel> Cores, IEnumerable<GradeModel> CoreAlt, IEnumerable<GradeModel> Electives);
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

}