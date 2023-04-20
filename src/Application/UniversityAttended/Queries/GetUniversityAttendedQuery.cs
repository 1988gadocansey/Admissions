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

namespace OnlineApplicationSystem.Application.UniversityAttended.Queries;

public record GetUniversityAttendedQuery : IRequest<PaginatedList<UniversityAttendedDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResearchExperienceHandler : IRequestHandler<GetUniversityAttendedQuery, PaginatedList<UniversityAttendedDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetResearchExperienceHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<PaginatedList<UniversityAttendedDto>> Handle(GetUniversityAttendedQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        var results = await _context.UniversityAttendedModels
                     .Where(r => r.Applicant == applicantDetails.Id).OrderBy(s => s.StartYear)
                     .ProjectTo<UniversityAttendedDto>(_mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}