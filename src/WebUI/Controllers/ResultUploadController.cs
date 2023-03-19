using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.Results.Commands;
using OnlineApplicationSystem.Application.Results.Queries;

namespace WebUI.Controllers;

[Authorize]
public class ResultUploadController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ResultsDto>>> Get([FromQuery] GetResultQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateResultRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteResultRequest(id));

        return NoContent();
    }
}