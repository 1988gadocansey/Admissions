using MediatR;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Biodata.Commands.UpdateBiodata;

public class UpdateBiodataCommandHandler : IRequestHandler<UpdateBiodataRequest>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    public UpdateBiodataCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(UpdateBiodataRequest request, CancellationToken cancellationToken)
    {
        var applicant = await _context.ApplicantModels
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), request.Id);
        }
        applicant.Title = request.Title;
        applicant.ApplicationUserId = _currentUserService.UserId;
        applicant.ApplicationNumber = Domain.ValueObjects.ApplicationNumber.Create(request.ApplicationNumber);
        applicant.ApplicantName = Domain.ValueObjects.ApplicantName.Create(request.FirstName, request.LastName, request.OtherName);
        applicant.Title = request.Title;
        applicant.Gender = request.Gender;
        applicant.Email = Domain.ValueObjects.EmailAddress.Create(request.Email);
        _context.ApplicantModels.Add(applicant);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}