using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetRegionQuery : IRequest<RegionModel>;

public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, RegionModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetRegionQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<RegionModel> Handle(GetRegionQuery request, CancellationToken cancellationToken)
    {

        return await _applicantRepository.Regions(cancellationToken);
    }
}