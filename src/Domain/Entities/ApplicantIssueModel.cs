using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities
{
    public class ApplicantIssueModel : BaseAuditableEntity
    {
        public int ApplicantId { set; get; }
        public virtual ApplicantModel Applicant { set; get; }
        public string? Issue { set; get; }
    }
}