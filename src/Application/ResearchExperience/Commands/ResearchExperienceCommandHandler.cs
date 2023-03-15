using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.ResearchExperience.Commands;

public class ResearchExperienceCommandHandler : IRequestHandler<ResearchExperienceRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    public ResearchExperienceCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;

    }
    public async Task<int> Handle(ResearchExperienceRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);

        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id); ;
        var data = new ResearchExperienceDto
        {
            Applicant = request.Applicant,
            Month = request.Month,
            AreaOfResearchIfAdmitted = request.AreaOfResearchIfAdmitted,
            FutureResearchInterest = request.FutureResearchInterest,
            ActualAreaOfResearch = request.ActualAreaOfResearch,
            Title = request.Title
        };
        var dataMapped = _mapper.Map<ResearchModel>(data);
        await _context.ResearchModels.AddAsync(dataMapped, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}