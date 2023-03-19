using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.Referee.Commands;
using OnlineApplicationSystem.Application.Referee.Queries;
namespace WebUI.Controllers;

[Authorize]
public class RefereeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<RefereeDto>>> Get([FromQuery] GetRefereeQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRefereeRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteeRefereeRequest(id));

        return NoContent();
    }
}