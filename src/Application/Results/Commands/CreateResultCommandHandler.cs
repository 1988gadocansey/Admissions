using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Results.Commands;

public class CreateResultCommandHandler : IRequestHandler<CreateResultRequest, int>
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
        var subject = await _context.SubjectModels.FirstOrDefaultAsync(s => s.Id == request.SubjectID, cancellationToken: cancellationToken);
        var grade = await _context.GradeModels.FirstOrDefaultAsync(s => s.Id == request.GradeID, cancellationToken: cancellationToken);
        if (userDetails.Category != "Undergraduate" || userDetails.Foriegn == true) return 0;
        var resultDetails = new ResultUploadModel
        {
            Subject = subject,
            Form = (int)Convert.ToInt64(formNo),
            Sitting = request.Sitting,
            Year = request.Year,
            ApplicantModelID = applicantDetails.Id,
            ExamType = request.ExamType,
            Center = request.Center,
            IndexNo = request.IndexNo,
            Month = request.Month,
            Grade = grade
        };
        await _context.ResultUploadModels.AddAsync(resultDetails, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return resultDetails.Id;
    }
}