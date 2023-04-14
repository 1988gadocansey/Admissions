using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.ProgrammeInformation.Commands;

namespace WebUI.Controllers;

[Authorize]
public class ProgrammeInformationController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(ProgrammeInfoRequest command) => await Mediator.Send(command);
}