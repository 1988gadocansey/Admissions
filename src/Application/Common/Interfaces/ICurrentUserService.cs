using OnlineApplicationSystem.Application.User.Queries;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface ICurrentUserService
{
    public string? UserId { get; }

    // public Task<UserDto> GetApplicationUserDetails(string? userId);




}
