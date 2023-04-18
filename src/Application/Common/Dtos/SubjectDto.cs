using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record SubjectDto : IMapFrom<SubjectModel>
{
    public int? Id { set; get; }
    public string? Exam { set; get; }
    public string? Type { set; get; }
    public string? Name { set; get; }

}