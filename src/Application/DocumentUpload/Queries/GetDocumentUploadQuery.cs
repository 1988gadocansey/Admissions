using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.DocumentUpload.Queries;


public record GetDocumentUploadQuery : IRequest<PaginatedList<DocumentUploadDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetDocumentUploadQueryHandler : IRequestHandler<GetDocumentUploadQuery, PaginatedList<DocumentUploadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetDocumentUploadQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<PaginatedList<DocumentUploadDto>> Handle(GetDocumentUploadQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        var results = await _context.DocumentUploadModels.Include(g => g.Applicant)

                     .Where(r => r.Applicant == applicantDetails.Id).OrderBy(s => s.Name)
                     .ProjectTo<DocumentUploadDto>(_mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}