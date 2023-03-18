using System.Reflection;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Infrastructure.Identity;
using OnlineApplicationSystem.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OnlineApplicationSystem.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<RefereeModel> RefereeModels => Set<RefereeModel>();
    public DbSet<ApplicantModel> ApplicantModels => Set<ApplicantModel>();
    public DbSet<ConfigurationModel> ConfigurationModels => Set<ConfigurationModel>();
    public DbSet<ResearchPublicationModel> ResearchPublicationModels { get; }
    public DbSet<FormNoModel> FormNoModels => Set<FormNoModel>();
    public DbSet<AcademicExperienceModel> AcademicExperienceModels => Set<AcademicExperienceModel>();
    public DbSet<BankModel> BankModels => Set<BankModel>();
    public DbSet<FormerSchoolModel> FormerSchoolModels => Set<FormerSchoolModel>();
    public DbSet<DenominationModel> DenominationModels => Set<DenominationModel>();
    public DbSet<DepartmentModel> DepartmentModels => Set<DepartmentModel>();
    public DbSet<DistrictModel> DistrictModels => Set<DistrictModel>();
    public DbSet<DocumentUploadModel> DocumentUploadModels => Set<DocumentUploadModel>();
    public DbSet<ExamModel> ExamModels => Set<ExamModel>();
    public DbSet<FacultyModel> FacultyModels => Set<FacultyModel>();

    public DbSet<HallModel> HallModels => Set<HallModel>();
    public DbSet<RegionModel> RegionModels => Set<RegionModel>();
    public DbSet<ReligionModel> ReligionModels => Set<ReligionModel>();
    public DbSet<RequirementModel> RequirementModels => Set<RequirementModel>();
    public DbSet<SchoolModel> SchoolModels => Set<SchoolModel>();
    public DbSet<SMSModel> SMSModels => Set<SMSModel>();
    public DbSet<SubjectModel> SubjectModels => Set<SubjectModel>();
    public DbSet<SHSProgrammes> SHSProgrammes => Set<SHSProgrammes>();
    public DbSet<CountryModel> CountryModels => Set<CountryModel>();
    public DbSet<Address> Addresss => Set<Address>();
    public DbSet<LanguageModel> Languages => Set<LanguageModel>();
    public DbSet<ProgrammeModel> ProgrammeModels => Set<ProgrammeModel>();
    public DbSet<ResultUploadModel> ResultUploadModels => Set<ResultUploadModel>();
    public DbSet<WorkingExperienceModel> WorkingExperienceModels => Set<WorkingExperienceModel>();
    public DbSet<ApplicantIssueModel> ApplicantIssueModels => Set<ApplicantIssueModel>();
    public DbSet<ResearchPublicationModel> ResearchPublications => Set<ResearchPublicationModel>();
    public DbSet<ResearchModel> ResearchModels => Set<ResearchModel>();

    public DbSet<GradeModel> GradeModels => Set<GradeModel>();

    public DbSet<DisabilitiesModel> DisabilitiesModels => Set<DisabilitiesModel>();

    public DbSet<UniversityAttendedModel> UniversityAttendedModels => Set<UniversityAttendedModel>();

    public DbSet<SHSAttendedModel> SHSAttendedModels => Set<SHSAttendedModel>();


    //public DbSet<GradeModel> GradeModels => Set<GradeModels>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }


}