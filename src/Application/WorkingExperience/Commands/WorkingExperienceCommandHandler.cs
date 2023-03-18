using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.WorkingExperience.Commands;

public class WorkingExperienceCommandHandler : IRequestHandler<WorkingExperienceRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    public WorkingExperienceCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<int> Handle(WorkingExperienceRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id); ;
        var data = new WorkingExperienceDto
        {
            Applicant = applicantDetails.Id,
            CompanyAddress = request.CompanyAddress,
            CompanyFrom = request.CompanyFrom,
            CompanyName = request.CompanyName,
            CompanyPhone = request.CompanyPhone,
            CompanyPosition = request.CompanyPosition,
            CompanyTo = request.CompanyTo
        };
        var dataMapped = _mapper.Map<WorkingExperienceModel>(data);
        await _context.WorkingExperienceModels.AddAsync(dataMapped, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}