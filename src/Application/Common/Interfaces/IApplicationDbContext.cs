using OnlineApplicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }


    DbSet<ApplicantModel> ApplicantModel { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    // Task<int> CommitAsync(CancellationToken cancellationToken);

}
