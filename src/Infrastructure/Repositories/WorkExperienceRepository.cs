using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class WorkExperienceRepository:Repository<WorkingExperienceModel>, IWorkExperienceRepository
{
    public WorkExperienceRepository(ApplicationDbContext context) : base(context)
    {
    }
}