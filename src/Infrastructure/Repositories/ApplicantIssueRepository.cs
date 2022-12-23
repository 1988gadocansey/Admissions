using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ApplicantIssueRepository:Repository<ApplicantIssueModel>, IApplicantIssueRepository
{
    public ApplicantIssueRepository(ApplicationDbContext context) : base(context)
    {
    }
}