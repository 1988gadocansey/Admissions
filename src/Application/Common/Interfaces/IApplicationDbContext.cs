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

    DbSet<ApplicantIssueModel> ApplicantIssueModels { get; }
    DbSet<FormNoModel> FormNoModels { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    // Task<int> CommitAsync(CancellationToken cancellationToken);

}
