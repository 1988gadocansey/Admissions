using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.ResearchPublication.Commands;
using OnlineApplicationSystem.Application.ResearchPublication.Queries;

namespace WebUI.Controllers;

[Authorize]
public class ResearchPublicationController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ResearchPublicationDto>>> Get([FromQuery] GetResearchPublicationQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(ResearchPublicationRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteResearchPublicationRequest(id));

        return NoContent();
    }
}