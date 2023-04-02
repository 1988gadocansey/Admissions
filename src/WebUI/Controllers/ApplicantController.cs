using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;
namespace WebUI.Controllers;

[Authorize]
public class ApplicantController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApplicantVm>> Get()
    {
        return await Mediator.Send(new GetApplicantQuery());
    }


}