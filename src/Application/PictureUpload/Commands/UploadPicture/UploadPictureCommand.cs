using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
namespace OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;

public class UploadPictureCommand : IRequestHandler<UploadPictureRequest, UrlsDto>
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
    public async Task<UrlsDto> Handle(UploadPictureRequest request, CancellationToken cancellationToken)
    {
        var urls = await _photoUploadService.UploadAsync(request.Files);
        var PictureUpload = await _photoUploadService.SendFileToServer(_currentUserService.UserId, request.Files, cancellationToken);
        await _identityService.UpdateApplicationPictureStatus(_currentUserService.UserId, request.Files, cancellationToken);

        return urls;
    }
}
