using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetSHSProgrammesQuery : IRequest<IEnumerable<SHSProgrammesDto>>;

public class GetSHSProgrammesQueryHandler : IRequestHandler<GetSHSProgrammesQuery, IEnumerable<SHSProgrammesDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetSHSProgrammesQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<SHSProgrammesDto>> Handle(GetSHSProgrammesQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.SHSProgrammes(cancellationToken);
        return data;
    }

}