using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record ApplicantIssueDto : IMapFrom<ApplicantIssueModel>
{
    public int Id { set; get; }
    public int ApplicantId { set; get; }
    public string? Issue { set; get; }

}