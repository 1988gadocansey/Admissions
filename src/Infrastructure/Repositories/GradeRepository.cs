using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class GradeRepository : Repository<GradeModel>, IGradeRepository
{
    public GradeRepository(ApplicationDbContext context) : base(context)
    {

    }
}