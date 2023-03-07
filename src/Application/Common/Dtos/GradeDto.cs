
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record GradeDto : IMapFrom<GradeModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public decimal? Value { set; get; }

}