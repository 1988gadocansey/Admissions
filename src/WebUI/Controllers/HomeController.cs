using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.User.Queries;

namespace OnlineApplicationSystem.WebUI.Controllers;

[Authorize]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> Dashboard()
    {
        return await Mediator.Send(new GetUserQuery());
    }
}