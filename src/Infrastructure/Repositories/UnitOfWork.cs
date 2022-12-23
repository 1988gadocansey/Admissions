using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;
using Domain.Interfaces;

namespace CleanArchitecture.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IApplicantRepository ApplicantModel => new ApplicantRepository(_context);
    public IResultRepository ResultModel => new ResultRepository(_context);
    public IGradeRepository GradeModel => new GradeRepository(_context);
    public IWorkExperienceRepository WorkingExperienceModel => new WorkExperienceRepository(_context);
    public IAcademicExperienceRepository AcademicExperienceModel => new AcademicExperienceRepository(_context);
    public IDocumentUploadRepository DocumentUploadModel => new DocumentUploadRepository(_context);

   // public IUserRepository UserModel => new UserRepository(_context);

    public IRefereeRepository RefereeModel => new RefereeRepository(_context);

    public IApplicantIssueRepository ApplicantIssueModel => new ApplicantIssueRepository(_context);
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}