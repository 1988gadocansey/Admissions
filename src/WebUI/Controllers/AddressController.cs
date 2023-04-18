using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Address.Commands;
using OnlineApplicationSystem.Application.Address.Queries;
namespace WebUI.Controllers;

[Authorize]
public class AddressController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateAddressRequest command) => await Mediator.Send(command);
    [HttpGet]
    public async Task<ActionResult<AddressDto>> Get() => await Mediator.Send(new GetAddressQuery());
}