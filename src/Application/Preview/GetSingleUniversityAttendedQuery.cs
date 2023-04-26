using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;


namespace OnlineApplicationSystem.Application.Preview;

public record GetSingleUniversityAttendedQuery : IRequest<UniversityAttendedDto>;

public class GetSingleUniversityAttendedQueryHandler : IRequestHandler<GetSingleUniversityAttendedQuery, UniversityAttendedDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetSingleUniversityAttendedQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;
        _identityService = identityService;

    }

    public async Task<UniversityAttendedDto> Handle(GetSingleUniversityAttendedQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        return await _applicantRepository.GetSingleUniversityAttended(applicantDetails.Id, cancellationToken);

    }

}
