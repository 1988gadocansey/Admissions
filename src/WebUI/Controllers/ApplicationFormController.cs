using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebUI.Controllers;
[Authorize]
public class ApplicationFormController :  ApiControllerBase
{
    private readonly ILogger<ApplicationFormController> _logger;
    private readonly ApplicationDbContext _dbContext;
    readonly RestClient _client;
    private readonly IHelper _helper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationFormController(ILogger<ApplicationFormController> logger, IHelper helper,
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, RestClient client) {
        _logger = logger;
        _userManager = userManager;
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _client = client;
        _helper = helper;
    }
    [HttpGet]
    public  async Task<IActionResult> IndexAsync(){
        
       // return await Mediator.Send(query);
       return Ok();
    }
}