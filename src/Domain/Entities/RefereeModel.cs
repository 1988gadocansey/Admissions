namespace OnlineApplicationSystem.Domain.Entities;
using Enums;
public class RefereeModel : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Institution { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public int ApplicantModelID { set; get; }
    private ICollection<ApplicantModel?> ApplicantModel { get; set; }

    public RefereeStatus refereeStatus { get; set; } = RefereeStatus.Pending;

    public RefereeModel()
    {

    }
}