using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Enums;
namespace OnlineApplicationSystem.Application.FormCategories.Query;

public record CreateFormUpdateRequest : IRequest<bool>
{
    public ApplicationType FormType { get; set; }
}
public class UpdateFormCategoryCommandHandler : IRequestHandler<CreateFormUpdateRequest, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;
    public UpdateFormCategoryCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }
    public async Task<bool> Handle(CreateFormUpdateRequest request, CancellationToken cancellationToken)
    {

        // update user form category logic goes here
        var userData = await _identityService.ChangeApplicantFormType(_currentUserService.UserId, request.FormType.ToString());
        if (userData == true)
        {
            return true;
        }
        return false;
    }
}