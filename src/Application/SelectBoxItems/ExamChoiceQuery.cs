using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetExamQuery : IRequest<IEnumerable<ExamDto>>;

public class GetExamQueryHandler : IRequestHandler<GetExamQuery, IEnumerable<ExamDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetExamQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<ExamDto>> Handle(GetExamQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Exams(cancellationToken);
        return data;
    }

}