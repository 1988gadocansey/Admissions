using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record ExamResultDto : IMapFrom<ExamModel>
{
    public int? Id { set; get; }
    public int? Exam { set; get; }


}