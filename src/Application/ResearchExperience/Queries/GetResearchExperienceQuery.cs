using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Application.Common.Models;

namespace OnlineApplicationSystem.Application.ResearchExperience.Queries;

public record GetResearchExperienceQuery : IRequest<PaginatedList<ResearchExperienceDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResearchExperienceHandler : IRequestHandler<GetResearchExperienceQuery, PaginatedList<ResearchExperienceDto>>
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
    public async Task<PaginatedList<ResearchExperienceDto>> Handle(GetResearchExperienceQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        var results = await _context.ResearchModels.Include(g => g.Applicant)

                     .Where(r => r.Applicant.Id == applicantDetails.Id).OrderBy(s => s.Month)
                     .ProjectTo<ResearchExperienceDto>(_mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}