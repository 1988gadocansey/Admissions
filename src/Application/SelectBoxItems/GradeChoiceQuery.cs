using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetGradeQuery : IRequest<IEnumerable<GradeDto>>;

public class GetGradeQueryHandler : IRequestHandler<GetGradeQuery, IEnumerable<GradeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetGradeQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<GradeDto>> Handle(GetGradeQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Grades(cancellationToken);
        return data;
    }

}