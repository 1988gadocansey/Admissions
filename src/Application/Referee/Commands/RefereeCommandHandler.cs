using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Referee.Commands;

public class RefereeCommandHandler : IRequestHandler<CreateRefereeRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public RefereeCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;

    }
    public async Task<int> Handle(CreateRefereeRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        //var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(s => s.Id == request.Applicant, cancellationToken: cancellationToken);

        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id); ;
        var data = new RefereeDto
        {
            Applicant = request.ApplicantModel,
            Institution = request.Institution,
            Name = request.Name,
            Email = request.Email,
            Position = request.Position

        };
        var dataMapped = _mapper.Map<RefereeModel>(data);
        await _context.RefereeModels.AddAsync(dataMapped, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return request.Id;
    }
}