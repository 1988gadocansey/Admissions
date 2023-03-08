using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;

namespace WebUI.Controllers;

[Authorize]
public class PreviewController : ApiControllerBase
{
    [HttpGet("preview")]
    public async Task<ActionResult<ApplicantVm>> Dashboard()
    {
        return await Mediator.Send(new GetApplicantQuery());
    }
    // download the preview form as pdf
    /*  [HttpGet("export")]
     public async Task<FileResult<ApplicantVm>> Get()
     {
         var vm = await Mediator.Send(new GetApplicantQuery());

         return File(vm.Content, vm.ContentType, vm.FileName);
     } */
}