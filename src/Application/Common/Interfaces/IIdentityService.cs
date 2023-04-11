using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.Common.Dtos;
namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    public Task Finalized(string userId);
    Task<Result> DeleteUserAsync(string userId);

    public Task<UserDto> GetApplicationUserDetails(string? userId, CancellationToken cancellationToken);

    Task UpdateApplicationPictureStatus(string? userId, ICollection<FileDto> photo, CancellationToken cancellationToken);

    Task<bool> ChangeApplicantFormType(string? userId, string? formType);
}
