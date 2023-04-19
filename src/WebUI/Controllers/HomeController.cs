using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.User.Queries;

namespace WebUI.Controllers;

[Authorize]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> Dashboard() => await Mediator.Send(new GetUserQuery());
    [HttpGet("grade")]
    public async Task<ActionResult<int>> GetGrade() => await Mediator.Send(new GetGradeQuery());
    [HttpGet("progress")]
    public async Task<ActionResult<ProgressDto>> GetProgress() => await Mediator.Send(new GetProgressQuery());
}