using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.WebUI.Controllers;

namespace WebUI.Controllers;

[Authorize]
public class ApplicantController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBiodataRequest command)
    {
        return await Mediator.Send(command);
    }
}