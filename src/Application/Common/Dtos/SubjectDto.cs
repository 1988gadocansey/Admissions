using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record SubjectDto : IMapFrom<SubjectModel>
{
    public int? Id { set; get; }
    public int? Exam { set; get; }
    public int? Type { set; get; }
    public string? Name { set; get; }

}