using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Results.Commands;

/* public class CreateResultCommandHandler : IRequestHandler<CreateResultRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public CreateResultCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;

    }
    public async Task<int> Handle(CreateResultRequest request, CancellationToken cancellationToken)
    {

        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var formNo = userDetails.FormNo;
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);

        var resultDetails = new ResultUploadModel
        {
            Subject = request.SubjectID.
    }

}
} */