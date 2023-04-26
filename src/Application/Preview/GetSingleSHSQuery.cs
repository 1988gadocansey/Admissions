using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace OnlineApplicationSystem.Application.Preview;

public record GetSingleSHSQuery : IRequest<SHSAttendedDto>;

public class GetSingleSHSQueryQueryHandler : IRequestHandler<GetSingleSHSQuery, SHSAttendedDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetSingleSHSQueryQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;
        _identityService = identityService;

    }

    public async Task<SHSAttendedDto> Handle(GetSingleSHSQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        return await _applicantRepository.GetSingleSHSAttended(applicantDetails.Id, cancellationToken);

    }

}
