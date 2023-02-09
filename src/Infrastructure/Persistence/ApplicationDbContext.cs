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
    public DbSet<ApplicantModel> ApplicantModel => Set<ApplicantModel>();
    public DbSet<ConfigurationModel> ConfigurationModel => Set<ConfigurationModel>();
    public DbSet<FormNoModel> FormNoModel => Set<FormNoModel>();
    public DbSet<AcademicExperienceModel> AcademicExperienceModel => Set<AcademicExperienceModel>();
    public DbSet<BankModel> BankModel => Set<BankModel>();
    public DbSet<FormerSchoolModel> FormerSchoolModel => Set<FormerSchoolModel>();
    public DbSet<DenominationModel> DenominationModel => Set<DenominationModel>();
    public DbSet<DepartmentModel> DepartmentModel => Set<DepartmentModel>();
    public DbSet<DistrictModel> DistrictModel => Set<DistrictModel>();
    public DbSet<DocumentUploadModel> DocumentUploadModel => Set<DocumentUploadModel>();
    public DbSet<ExamModel> ExamModel => Set<ExamModel>();
    public DbSet<FacultyModel> FacultyModel => Set<FacultyModel>();
    public DbSet<GradeModel> GradeModel => Set<GradeModel>();
    public DbSet<HallModel> HallModel => Set<HallModel>();
    public DbSet<RegionModel> RegionModel => Set<RegionModel>();
    public DbSet<ReligionModel> ReligionModel => Set<ReligionModel>();
    public DbSet<RequirementModel> RequirementModel => Set<RequirementModel>();
    public DbSet<SchoolModel> SchoolModel => Set<SchoolModel>();
    public DbSet<SMSModel> SMSModel => Set<SMSModel>();
    public DbSet<SubjectModel> SubjectModel => Set<SubjectModel>();
    public DbSet<SHSProgrammes> SHSProgrammes => Set<SHSProgrammes>();
    public DbSet<CountryModel> CountryModel => Set<CountryModel>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<LanguageModel> LanguageModel => Set<LanguageModel>();
    public DbSet<ProgrammeModel> ProgrammeModel => Set<ProgrammeModel>();
    public DbSet<ResultUploadModel> ResultUploadModel => Set<ResultUploadModel>();
    public DbSet<WorkingExperienceModel> WorkingExperienceModel => Set<WorkingExperienceModel>();
    public DbSet<ApplicantIssueModel> ApplicantIssueModel => Set<ApplicantIssueModel>();
    public DbSet<ResearchPublication> ResearchPublications => Set<ResearchPublication>();
    public DbSet<ResearchModel> Researches => Set<ResearchModel>();

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
