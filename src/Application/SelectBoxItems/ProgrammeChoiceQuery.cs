using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetProgrammeQuery : IRequest<ProgrammeModel>;

public class GetProgrammeQueryHandler : IRequestHandler<GetProgrammeQuery, ProgrammeModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    public GetProgrammeQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;

    }

    public async Task<ProgrammeModel> Handle(GetProgrammeQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await _identityService.GetApplicationUserDetails(_currentUserService.UserId, cancellationToken);

        var types = new Dictionary<string, string>
            {
                { "DIPLOMA", "DipTECH" },
                { "MTECH", "MTECH" },
                { "BTECH", "DEGREE" },
                { "MATURE", "BTECH" },
                { "TOPUP", "BTECH" },
                { "BRIDGING", "BTECH" },
                 { "CERTIFICATE", "CERT" },
                { "HND", "HND" },
                { "ACCELERATED", "BTECH" }
            };
        var formType = types.FirstOrDefault(x => x.Value == userDetails.Type).Value;

        return _applicantRepository.Programmes(formType);
    }
}