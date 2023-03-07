using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetFormerSchoolQuery : IRequest<IEnumerable<FormerSchoolDto>>;

public class GetFormerSchoolQueryHandler : IRequestHandler<GetFormerSchoolQuery, IEnumerable<FormerSchoolDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetFormerSchoolQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<FormerSchoolDto>> Handle(GetFormerSchoolQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Schools(cancellationToken);
        return data;
    }

}