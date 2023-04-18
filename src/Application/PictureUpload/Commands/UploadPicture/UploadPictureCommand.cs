using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;

public class UploadPictureCommand : IRequestHandler<UploadPictureRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IPhotoUploadService _photoUploadService;
    private readonly IIdentityService _identityService;
    public UploadPictureCommand(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IPhotoUploadService photoUploadService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _photoUploadService = photoUploadService;


    }
    /*  public async Task<Unit> Handle(UploadPictureRequest request, CancellationToken cancellationToken)
     {

         await _identityService.UpdateApplicationPictureStatus(request.UserId, null, cancellationToken);


         return Unit.Value;
     } */
    public async Task<int> Handle(UploadPictureRequest request, CancellationToken cancellationToken)
    {
        var pictureUpload = await _photoUploadService.SendFileToServer(_currentUserService.UserId, request.Files, cancellationToken);
        await _identityService.UpdateApplicationPictureStatus(_currentUserService.UserId, request.Files, cancellationToken);
        //lets create issue flag here
        var applicant = _context.ApplicantIssueModels.FirstOrDefault(u => u.ApplicationUserId == _currentUserService.UserId);

        if (applicant == null)
        {
            var issueFlag = (pictureUpload == 1) ? true : false;
            var issue = new ApplicantIssueModel { Picture = issueFlag, ApplicationUserId = _currentUserService.UserId };
            _context.ApplicantIssueModels.Add(issue);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            applicant.Picture = (pictureUpload == 1) ? true : false;
            await _context.SaveChangesAsync(cancellationToken);
        }


        return pictureUpload;
    }
}
