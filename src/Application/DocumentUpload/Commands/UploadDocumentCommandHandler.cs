using FluentValidation;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;


public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IDocumentUploadService _documentUploadService;
    private readonly IIdentityService _identityService;
    public UploadDocumentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IDocumentUploadService documentUploadService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _documentUploadService = documentUploadService;


    }
    /*  public async Task<Unit> Handle(UploadPictureRequest request, CancellationToken cancellationToken)
     {

         await _identityService.UpdateApplicationPictureStatus(request.UserId, null, cancellationToken);


         return Unit.Value;
     } */
    public async Task<int> Handle(UploadDocumentRequest request, CancellationToken cancellationToken)
    {
        var pictureUpload = await _documentUploadService.SendFileToServer(_currentUserService.UserId, request.Files, cancellationToken);
        await _identityService.UpdateApplicationPictureStatus(_currentUserService.UserId, request.Files, cancellationToken);



        return pictureUpload;
    }
}
