using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;

namespace WebUI.Controllers;

[Authorize]
public class BiodataController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBiodataRequest command)
    {
        return await Mediator.Send(command);
    }
}