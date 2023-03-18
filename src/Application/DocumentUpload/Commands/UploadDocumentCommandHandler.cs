using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;


public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDocumentUploadService _documentUploadService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    private readonly IApplicantRepository _applicantRepository;
    public UploadDocumentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IApplicantRepository applicantRepository, IIdentityService identityService, IDocumentUploadService documentUploadService, IMapper mapper)
    {
        _context = context;
        _currentUserService = currentUserService;
        _applicantRepository = applicantRepository;
        _identityService = identityService;
        _documentUploadService = documentUploadService;
        _mapper = mapper;


    }
    public async Task<int> Handle(UploadDocumentRequest request, CancellationToken cancellationToken)
    {


        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        var pictureUpload = await _documentUploadService.UploadFiles(applicantDetails.ApplicationNumber, request.Files, cancellationToken);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id); ;
        var documentDetails = new DocumentUploadDto
        {
            Id = request.Id,
            Type = request.Type,
            Name = request.Name,
            Applicant = applicantDetails.Id
        };

        var dataMapped = _mapper.Map<DocumentUploadModel>(documentDetails);
        await _context.DocumentUploadModels.AddAsync(dataMapped, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await _documentUploadService.DeleteFile(applicantDetails.ApplicationNumber, request.Name, cancellationToken);
        return documentDetails.Id;

    }
}
