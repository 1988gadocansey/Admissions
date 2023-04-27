using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.User.Queries;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IApplicationFormTypeService
{
    public UserDto user { get; }

    //private Task<ApplicationUser> GetCurrentUserAsync { get; }

}
