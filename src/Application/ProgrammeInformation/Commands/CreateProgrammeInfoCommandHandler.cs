using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Application.Common.Exceptions;

namespace OnlineApplicationSystem.Application.ProgrammeInformation.Commands;

public class CreateProgrammeInfoCommandHandler : IRequestHandler<ProgrammeInfoRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;

    public CreateProgrammeInfoCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }
    public async Task<int> Handle(ProgrammeInfoRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicant = await _context.ApplicantModels
          .FindAsync(new object[] { request.Id }, cancellationToken);

        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), request.Id);
        }
        applicant.LastYearInSchool = request.LastYearInSchool;
        applicant.EntryMode = request.EntryMode;
        applicant.FirstChoiceId = request.FirstChoiceId;
        applicant.SecondChoiceId = request.SecondChoiceId;
        applicant.ThirdChoiceId = request.ThirdChoiceId;
        applicant.FirstQualification = request.FirstQualification;
        applicant.SecondQualification = request.SecondQualification;
        applicant.Awaiting = request.Awaiting;
        applicant.Grade = request.Grade;
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result == 1)
        {
            return 200;
        }
        return 500;

    }
}