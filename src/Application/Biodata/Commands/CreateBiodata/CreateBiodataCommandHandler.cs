using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler : IRequestHandler<CreateBiodataRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    public CreateBiodataCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }
    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        var applicant = new ApplicantModel
        {
            ApplicationUserId = _currentUserService.UserId,
            ApplicationNumber = Domain.ValueObjects.ApplicationNumber.Create(request.ApplicationNumber),
            ApplicantName = Domain.ValueObjects.ApplicantName.Create(request.FirstName, request.LastName, request.OtherName),
            Title = request.Title,
            Gender = request.Gender,
            Email = Domain.ValueObjects.EmailAddress.Create(request.Email)
        };
        _context.ApplicantModels.Add(applicant);
        await _context.SaveChangesAsync(cancellationToken);
        // go to issue and update biodata done as true
        var applicantIssues = _context.ApplicantIssueModels.FirstOrDefault(u => u.ApplicantModelId == _currentUserService.UserId);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            _context.ApplicantIssueModels.Update(applicantIssues);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return applicant.Id;
    }
}