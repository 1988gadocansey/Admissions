using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record DisabilitiesDto : IMapFrom<DisabilitiesModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }

}