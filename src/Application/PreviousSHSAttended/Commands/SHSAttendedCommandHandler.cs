using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;
public class SHSAttendedCommandHandler : IRequestHandler<SHSAttendedRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public SHSAttendedCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;

    }
    public async Task<int> Handle(SHSAttendedRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var formNo = userDetails.FormNo;
        var applicantDetails = await _context.ApplicantModels.FirstOrDefaultAsync(A => A.ApplicationUserId == userId, cancellationToken);
        var school = await _context.FormerSchoolModels.FirstOrDefaultAsync(s => s.Id == request.NameId, cancellationToken: cancellationToken);
        var region = await _context.RegionModels.FirstOrDefaultAsync(a => a.Id == request.Region, cancellationToken: cancellationToken);
        if (userDetails.Category != "Undergraduate" || userDetails.Foriegn == true) return 0;
        var schoolDetails = new SHSAttendedModel
        {
            Name = school,
            // AttendedTTU = request.AttendedTTU,
            Applicant = applicantDetails,
            Location = region,
            StartYear = request.StartYear,
            EndYear = request.EndYear,
            ProgrammeStudied = request.ProgrammeStudied
        };
        await _context.SHSAttendedModels.AddAsync(schoolDetails, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return schoolDetails.Id;
    }
}