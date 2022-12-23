using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Domain.Entities;
namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IApplicantRepository ApplicantModel { get; }
    IResultRepository ResultModel { get; }
    IGradeRepository GradeModel { get; }
    IRefereeRepository RefereeModel { get; }
    IWorkExperienceRepository WorkingExperienceModel { get; }
    IDocumentUploadRepository DocumentUploadModel { get; }
    IAcademicExperienceRepository AcademicExperienceModel { get; }
    IApplicantIssueRepository ApplicantIssueModel { get; }
    Task CommitAsync();
}