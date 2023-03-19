using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.WorkingExperience.Commands;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.WorkingExperience.Queries;
public record GetWorkingExperienceQuery : IRequest<PaginatedList<WorkingExperienceDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetWorkingExperienceHandler : IRequestHandler<GetWorkingExperienceQuery, PaginatedList<WorkingExperienceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetWorkingExperienceHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<PaginatedList<WorkingExperienceDto>> Handle(GetWorkingExperienceQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        var results = await _context.WorkingExperienceModels.Include(g => g.ApplicantModel)

                     .Where(r => r.ApplicantModel.Id == applicantDetails.Id).OrderBy(s => s.CompanyFrom)
                     .ProjectTo<WorkingExperienceDto>(_mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}