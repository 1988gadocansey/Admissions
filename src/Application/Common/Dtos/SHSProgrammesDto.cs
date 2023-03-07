using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record SHSProgrammesDto : IMapFrom<SHSProgrammes>
{

    public int ID { set; get; }
    public string Name { get; set; }


}