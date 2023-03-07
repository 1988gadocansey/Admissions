using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record SHSAttendedDto : IMapFrom<SHSAttendedModel>
{
    public int Id { set; get; }
    public bool AttendedTTU { get; set; }
    public ApplicantModel? Applicant { get; set; }
    public FormerSchoolModel? Name { set; get; }
    public RegionModel? Location { set; get; }
    public string? StartYear { set; get; }
    public string? EndYear { set; get; }

}