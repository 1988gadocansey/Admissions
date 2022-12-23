
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class DocumentUploadModel: BaseAuditableEntity
{
   
    public int Applicant { set; get; }
    public string Name { set; get; }
    public string Type { set; get; }
    public DocumentUploadModel()
    {
    }
}