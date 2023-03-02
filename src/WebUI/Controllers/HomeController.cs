using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.User.Queries;

namespace WebUI.Controllers;

[Authorize]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> Dashboard()
    {
        return await Mediator.Send(new GetUserQuery());
    }
    // download the preview form as pdf
    /* [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    } */
}