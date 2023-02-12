using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using OnlineApplicationSystem.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.User.Queries;

[Authorize]
public record GetUserQuery : IRequest<UserDto>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        // Console.WriteLine($"user is " + _currentUserService.UserId);
        var userDetails = await _identityService.GetApplicationUserDetails(_currentUserService.UserId, cancellationToken);

        return userDetails;
    }
}