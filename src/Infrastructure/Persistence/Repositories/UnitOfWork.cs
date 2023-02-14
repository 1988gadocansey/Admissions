using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Contracts;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;

    public UnitOfWork(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /*   public async Task CommitAsync()
          => await _dbContext.SaveChangesAsync();
      public async Task RollbackAsync()
          => await _dbContext.DisposeAsync(); */
}