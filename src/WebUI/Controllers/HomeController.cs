using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.User.Queries;
using OnlineApplicationSystem.WebUI.Controllers;

namespace WebUI.Controllers;

[Authorize]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> Dashboard()
    {
        return await Mediator.Send(new GetUserQuery());
    }
}