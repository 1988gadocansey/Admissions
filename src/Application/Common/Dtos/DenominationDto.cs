using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record DenominationDto : IMapFrom<DenominationModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }


}