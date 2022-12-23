using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ApplicantRepository:Repository<ApplicantModel>, IApplicantRepository
{
    public ApplicantRepository(ApplicationDbContext context) : base(context)
    {
    }
}