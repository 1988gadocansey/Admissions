using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Biodata.CreateBiodata;

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
        var applicant = new ApplicantModel();
        applicant.ApplicationUserId = _currentUserService.UserId;
        applicant.ApplicationNumber = Domain.ValueObjects.ApplicationNumber.Create(request.ApplicationNumber);
        applicant.ApplicantName = Domain.ValueObjects.ApplicantName.Create(request.FirstName, request.LastName, request.OtherName);
        applicant.Title = request.Title;
        applicant.Gender = request.Gender;
        applicant.Email = Domain.ValueObjects.EmailAddress.Create(request.Email);
        _context.ApplicantModel.Add(applicant);
        await _context.SaveChangesAsync(cancellationToken);

        return applicant.Id;
    }
}