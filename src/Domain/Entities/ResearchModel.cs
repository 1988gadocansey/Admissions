using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities;

public class ResearchModel
{
    [Key]
    public int Id { set; get; }
    public string? Title { set; get; }
    public string? Month { set; get; }
    public string? AreaOfResearchIfAdmitted { set; get; }
    public string? ActualAreaOfResearch { set; get; }
    public string? FutureResearchInterest { set; get; }

}