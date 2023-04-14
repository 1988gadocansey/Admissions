using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Domain.ValueObjects;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Queries;
public record GetSHSAttendedQuery : IRequest<PaginatedList<SHSAttendedDto>>
{
    public int ResultId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetResultQueryHandler : IRequestHandler<GetSHSAttendedQuery, PaginatedList<SHSAttendedDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetResultQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<PaginatedList<SHSAttendedDto>> Handle(GetSHSAttendedQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        var results = await _context.SHSAttendedModels.Include(g => g.Applicant)
                     .Include(s => s.Location)
                     .Where(r => r.Applicant == applicantDetails.Id).OrderBy(s => s.StartYear).OrderBy(s => s.Location.Name)
                     .ProjectTo<SHSAttendedDto>(_mapper.ConfigurationProvider)
                     .PaginatedListAsync(request.PageNumber, request.PageSize);
        return results;
    }

}
