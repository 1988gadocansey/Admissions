using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;
using OnlineApplicationSystem.Application.FormCategories.Query;
namespace WebUI.Controllers;

[Authorize]
public class ApplicantController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApplicantVm>> Get()
    {
        return await Mediator.Send(new GetApplicantQuery());
    }

    [HttpGet("form/change")]
    public async Task<IEnumerable<ApplicationType>> GetForms() => await Mediator.Send(new GetFormsQuery());

    [HttpPost("form/change")]
    public async Task<ActionResult<bool>> SaveFormChanges(CreateFormUpdateRequest command) => await Mediator.Send(command);

}