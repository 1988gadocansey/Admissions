using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

namespace WebUI.Controllers;

[Authorize]
public class SHSAttendedController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<SHSAttendedDto>>> Get([FromQuery] GetSHSAttendedQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(SHSAttendedRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteSHSAttendedRequest(id));

        return NoContent();
    }
}