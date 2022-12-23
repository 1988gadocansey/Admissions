using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class RefereeRepository:Repository<RefereeModel>, IRefereeRepository
{
    public RefereeRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}