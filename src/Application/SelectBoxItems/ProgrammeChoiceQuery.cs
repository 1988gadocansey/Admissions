using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetProgrammeQuery : IRequest<IEnumerable<ProgrammeDto>>;

public class GetProgrammeQueryHandler : IRequestHandler<GetProgrammeQuery, IEnumerable<ProgrammeDto>>
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
    public async Task<IEnumerable<ProgrammeDto>> Handle(GetProgrammeQuery request, CancellationToken cancellationToken)
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


        var data = await _context.ProgrammeModels
         .OrderBy(n => n.Name)
          .Where(n => n.Type == formType).
        Select(b =>
        new ProgrammeDto()
        {
            Id = b.Id,
            Name = b.Name,
            Duration = b.Duration,
            Type = b.Type,
        }).ToListAsync(cancellationToken: cancellationToken);
        return data;


    }
}