using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.WorkingExperience.Commands;
using OnlineApplicationSystem.Application.WorkingExperience.Queries;

namespace WebUI.Controllers;

[Authorize]
public class WorkingExperienceController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<WorkingExperienceDto>>> Get([FromQuery] GetWorkingExperienceQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(WorkingExperienceRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteWorkingExperienceRequest(id));

        return NoContent();
    }
}