using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;

namespace OnlineApplicationSystem.Application.ProgrammeInformation.Queries;

public record GetProgrammeInfoQuery : IRequest<ApplicantVm>;

public class GetProgrammeInfoQueryHandler : IRequestHandler<GetApplicantQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetProgrammeInfoQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;

    }

    public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken) => await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
    /* public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        return await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
    } */
}
