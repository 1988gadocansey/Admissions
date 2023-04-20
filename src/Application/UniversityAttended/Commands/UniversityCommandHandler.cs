using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.UniversityAttended.Commands;
public class UniversityCommandHandler : IRequestHandler<UniversityAttendedRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    public UniversityCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _mapper = mapper;
    }
    public async Task<int> Handle(UniversityAttendedRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        var country = _context.CountryModels.FirstOrDefault(a => a.ID == request.Location);
        if (userDetails.Category == "Undergraduate") throw new NotFoundException("Only postgraduates allowed", request.Id); ;
        var data = new UniversityAttendedModel
        {
            Name = request.Name,
            Location = country,
            Applicant = applicantDetails.Id,
            CGPA = request.CGPA,
            StartYear = request.StartYear,
            EndYear = request.EndYear,
            StudentNumber = request.StudentNumber,
            DegreeObtained = request.DegreeObtained,
            DegreeClassification = request.DegreeClassification
        };
        // var dataMapped = _mapper.Map<UniversityAttendedModel>(data);
        await _context.UniversityAttendedModels.AddAsync(data, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return 200;
    }
}