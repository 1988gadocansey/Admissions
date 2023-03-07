using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record ExamDto : IMapFrom<ExamModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public int? CutOffPoint { set; get; }

}