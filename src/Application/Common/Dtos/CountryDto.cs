using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record CountryDto : IMapFrom<CountryModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }


}