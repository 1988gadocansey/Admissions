using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.ResearchExperience.Commands;
using OnlineApplicationSystem.Application.ResearchExperience.Queries;

namespace WebUI.Controllers;

[Authorize]
public class ResearchExperienceController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ResearchExperienceDto>>> Get([FromQuery] GetResearchExperienceQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(ResearchExperienceRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteResearchExperienceRequest(id));

        return NoContent();
    }
}