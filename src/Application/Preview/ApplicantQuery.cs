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


    public GetApplicantQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;

    }

    public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
        return data;
    }

}
