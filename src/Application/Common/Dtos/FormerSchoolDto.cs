namespace OnlineApplicationSystem.Application.Common.Dtos;

using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;
public record FormerSchoolDto : IMapFrom<FormerSchoolModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }

}