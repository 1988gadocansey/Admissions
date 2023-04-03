using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.ViewModels;

namespace OnlineApplicationSystem.Application.Preview;

public record GetApplicantQuery : IRequest<ApplicantVm>;

public class GetApplicantQueryHandler : IRequestHandler<GetApplicantQuery, ApplicantVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetApplicantQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper)
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
