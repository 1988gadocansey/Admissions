using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ResultRepository:Repository<ResultUploadModel>, IResultRepository
{
    public ResultRepository(ApplicationDbContext context) : base(context)
    {
    }
}