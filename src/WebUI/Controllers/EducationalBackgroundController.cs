using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;
using OnlineApplicationSystem.Application.PreviousSHSAttended.Queries;
using OnlineApplicationSystem.Application.UniversityAttended.Commands;
using OnlineApplicationSystem.Application.UniversityAttended.Queries;
namespace WebUI.Controllers;

[Authorize]

public class EducationalBackendController : ApiControllerBase
{
    [HttpGet("get/shs")]
    public async Task<ActionResult<PaginatedList<SHSAttendedDto>>> Get([FromQuery] GetSHSAttendedQuery query) => await Mediator.Send(query);
    [HttpPost("post/shs")]
    public async Task<ActionResult<int>> Create(SHSAttendedRequest command) => await Mediator.Send(command);
    [HttpDelete("delete/shs/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteSHSAttendedRequest(id));

        return NoContent();
    }
    [HttpGet("get/universityattended")]
    public async Task<ActionResult<PaginatedList<UniversityAttendedDto>>> GetUniversity([FromQuery] GetUniversityAttendedQuery query) => await Mediator.Send(query);
    [HttpPost("post/universityattended")]
    public async Task<ActionResult<int>> CreateUniversity(UniversityAttendedRequest command) => await Mediator.Send(command);
    [HttpDelete("delete/universityattended/{id}")]
    public async Task<ActionResult> DeleteUniversity(int id)
    {
        await Mediator.Send(new DeleteUniversityAttendedRequest(id));

        return NoContent();
    }

}