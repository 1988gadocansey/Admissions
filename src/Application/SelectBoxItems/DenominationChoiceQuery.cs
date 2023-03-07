using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetDenominationQuery : IRequest<IEnumerable<DenominationDto>>;

public class GetDenominationQueryHandler : IRequestHandler<GetDenominationQuery, IEnumerable<DenominationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetDenominationQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<DenominationDto>> Handle(GetDenominationQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Denominations(cancellationToken);
        return data;
    }

}