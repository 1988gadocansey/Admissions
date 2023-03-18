using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;
public record ResearchPublicationDto : IMapFrom<ResearchPublicationModel>
{
    public int Id { set; get; }
    public int Applicant { set; get; }
    public string? Publication { get; set; }

}