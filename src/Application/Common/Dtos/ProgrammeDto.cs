using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record ProgrammeDto : IMapFrom<ProgrammeModel>
{
    public int Id { set; get; }

    public string Name { set; get; }
    public string Code { set; get; }
    public string LevelAdmitted { set; get; }
    public bool Runing { set; get; }
    public bool ShowOnPortal { set; get; }
    public string Type { set; get; }
    public int Duration { set; get; }
    public int Department { set; get; }


}