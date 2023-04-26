using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;
using OnlineApplicationSystem.Application.SelectBoxItems;

using OnlineApplicationSystem.Application.Preview.Commands;
using OnlineApplicationSystem.Application.Common.Dtos;
namespace WebUI.Controllers;

[Authorize]
public class PreviewController : ApiControllerBase
{
    [HttpGet("preview")]
    public async Task<ActionResult<ApplicantVm>> Dashboard() => await Mediator.Send(new GetApplicantQuery());
    [HttpGet("finalpreview")]
    public async Task<ActionResult<ApplicantVm>> GetPreview() => await Mediator.Send(new GetApplicantQuery());
    [HttpGet("getshspreview")]
    public async Task<ActionResult<SHSAttendedDto>> GetSHS() => await Mediator.Send(new GetSingleSHSQuery());

    [HttpGet("getuniversitypreview")]
    public async Task<ActionResult<UniversityAttendedDto>> GetUniversity() => await Mediator.Send(new GetSingleUniversityAttendedQuery());




    [HttpPost("finalize")]
    public async Task<ActionResult<int>> Finalize(FinalizedRequest command) => await Mediator.Send(command);


    [HttpGet("getprogramme/{id}")]
    public async Task<ActionResult<ProgrammeDto>> GetProgrammeById(int id) => await Mediator.Send(new GetProgrammeByIdQuery { Id = id });







    // download the preview form as pdf
    /*  [HttpGet("export")]
     public async Task<FileResult<ApplicantVm>> Get()
     {
         var vm = await Mediator.Send(new GetApplicantQuery());

         return File(vm.Content, vm.ContentType, vm.FileName);
     } */
}