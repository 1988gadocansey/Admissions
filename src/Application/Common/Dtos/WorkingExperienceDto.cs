using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record WorkingExperienceDto
{
    public int Id { set; get; }
    public string? CompanyName { set; get; }
    public string? CompanyPhone { set; get; }
    public string? CompanyAddress { set; get; }
    public string? CompanyPosition { set; get; }
    public string? CompanyFrom { set; get; }
    public string? CompanyTo { set; get; }
    public int Applicant { set; get; }

}