using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record ResearchExperienceDto : IMapFrom<ResearchModel>
{

    public int Id { set; get; }
    public string? Title { set; get; }
    public string? Month { set; get; }
    public string? AreaOfResearchIfAdmitted { set; get; }
    public string? ActualAreaOfResearch { set; get; }
    public string? FutureResearchInterest { set; get; }
    public int Applicant { set; get; }
}