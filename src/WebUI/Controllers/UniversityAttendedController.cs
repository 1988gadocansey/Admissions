using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.UniversityAttended.Commands;
using OnlineApplicationSystem.Application.UniversityAttended.Queries;

namespace WebUI.Controllers;

[Authorize]
public class UniversityAttendedController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<UniversityAttendedDto>>> Get([FromQuery] GetUniversityAttendedQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(UniversityAttendedRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteUniversityAttendedRequest(id));

        return NoContent();
    }
}