
using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities;

public class DocumentUploadModel : BaseAuditableEntity
{

    public int Applicant { set; get; }
    public string Name { set; get; }
    public string Type { set; get; }
    public DocumentUploadModel()
    {
    }
}