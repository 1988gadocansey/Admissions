using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class DocumentUploadRepository:Repository<DocumentUploadModel>, IDocumentUploadRepository
{
    public DocumentUploadRepository(ApplicationDbContext context) : base(context)
    {
    }
}