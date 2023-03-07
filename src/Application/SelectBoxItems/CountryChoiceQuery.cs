using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetCountryQuery : IRequest<IEnumerable<CountryDto>>;

public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, IEnumerable<CountryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetCountryQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Countries(cancellationToken);
        return data;
    }

}