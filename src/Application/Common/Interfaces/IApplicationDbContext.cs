using OnlineApplicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<ApplicantModel> ApplicantModels { get; }
    DbSet<ConfigurationModel> ConfigurationModels { get; }
    DbSet<ResultUploadModel> ResultUploadModels { get; }
    DbSet<AcademicExperienceModel> AcademicExperienceModels { get; }
    DbSet<WorkingExperienceModel> WorkingExperienceModels { get; }
    DbSet<ResearchModel> ResearchModels { get; }
    DbSet<ResearchPublicationModel> ResearchPublicationModels { get; }
    DbSet<AddressModel> AddressModels { get; }

    DbSet<ProgressModel> ProgressModels { get; }
    DbSet<ApplicantIssueModel> ApplicantIssueModels { get; }
    DbSet<FormNoModel> FormNoModels { get; }
    DbSet<RegionModel> RegionModels { get; }
    DbSet<ReligionModel> ReligionModels { get; }
    DbSet<RefereeModel> RefereeModels { get; }
    DbSet<ProgrammeModel> ProgrammeModels { get; }
    DbSet<DistrictModel> DistrictModels { get; }
    DbSet<CountryModel> CountryModels { get; }
    DbSet<HallModel> HallModels { get; }
    DbSet<SubjectModel> SubjectModels { get; }
    DbSet<ExamModel> ExamModels { get; }
    DbSet<FormerSchoolModel> FormerSchoolModels { get; }
    DbSet<DenominationModel> DenominationModels { get; }
    DbSet<GradeModel> GradeModels { get; }
    DbSet<DisabilitiesModel> DisabilitiesModels { get; }
    DbSet<LanguageModel> Languages { get; }
    DbSet<SMSModel> SMSModels { get; }
    DbSet<DocumentUploadModel> DocumentUploadModels { get; }

    DbSet<SHSProgrammes> SHSProgrammes { get; }
    DbSet<SHSAttendedModel> SHSAttendedModels { get; }
    DbSet<UniversityAttendedModel> UniversityAttendedModels { get; }
    DbSet<UniversityModel> UniversityModels { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    // Task<int> CommitAsync(CancellationToken cancellationToken);

}
