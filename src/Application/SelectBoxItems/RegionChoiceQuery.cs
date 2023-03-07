using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetRegionQuery : IRequest<IEnumerable<RegionDto>>;

public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, IEnumerable<RegionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetRegionQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<RegionDto>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Regions(cancellationToken);
        return data;
    }

}