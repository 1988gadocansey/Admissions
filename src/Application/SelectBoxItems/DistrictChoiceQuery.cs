using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetDistrictQuery : IRequest<IEnumerable<DistrictDto>>;

public class GetDistrictQueryHandler : IRequestHandler<GetDistrictQuery, IEnumerable<DistrictDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetDistrictQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<DistrictDto>> Handle(GetDistrictQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Districts(cancellationToken);
        return data;
    }

}