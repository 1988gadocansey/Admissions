using AutoMapper;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.ViewModels;

namespace OnlineApplicationSystem.Application.User.Queries;

public record GetGradeQuery : IRequest<int>;

public class GetGradeQueryyHandler : IRequestHandler<GetGradeQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public GetGradeQueryyHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;

    }

    public Task<int> Handle(GetGradeQuery request, CancellationToken cancellationToken) => Task.FromResult(_applicantRepository.getGrade(_currentUserService.UserId));
    /* public async Task<ApplicantVm> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        return await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);
    } */
}
