using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class AcademicExperienceRepository:Repository<AcademicExperienceModel>, IAcademicExperienceRepository
{
    public AcademicExperienceRepository(ApplicationDbContext context) : base(context)
    {
    }
}