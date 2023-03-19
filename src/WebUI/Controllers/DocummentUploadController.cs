using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Models;
using OnlineApplicationSystem.Application.DocumentUpload.Commands;
using OnlineApplicationSystem.Application.DocumentUpload.Queries;

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
    public async Task<ActionResult<PaginatedList<DocumentUploadDto>>> Get([FromQuery] GetDocumentUploadQuery query)
    {
        return await Mediator.Send(query);
    }

}