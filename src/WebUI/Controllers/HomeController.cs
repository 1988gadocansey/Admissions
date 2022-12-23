using CleanArchitecture.Application.Applicant.Queries;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

/// <summary>
/// Jobs API for CRUD job 
/// </summary>
[Authorize]
public class HomeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserVm>>Get()
    {
        return await Mediator.Send(new GetUserQuery());
    }

}