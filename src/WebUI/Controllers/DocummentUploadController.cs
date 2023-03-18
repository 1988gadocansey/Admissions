using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.DocumentUpload.Commands;
using OnlineApplicationSystem.Application.DocumentUpload.Queries;
using OnlineApplicationSystem.Application.Preview;

namespace WebUI.Controllers;

[Authorize]
public class DocumentUploadController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(UploadDocumentRequest command)
    {
        return await Mediator.Send(command);
    }
    [HttpGet]
    public async Task<ActionResult<DocumentUploadDto>> Get()
    {
        return await Mediator.Send(new GetDocumentUploadQuery());
    }
}