using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.SelectBoxItems;

namespace WebUI.Controllers;

[Authorize]
public class SelectBoxController : ApiControllerBase
{
    [HttpGet("religions")]
    public async Task<IEnumerable<ReligionDto>> GetRegions()
    {
        return await Mediator.Send(new GetReligionQuery());
    }
}