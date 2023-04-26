using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.User.Queries;
using OnlineApplicationSystem.Infrastructure.Identity;

namespace OnlineApplicationSystem.WebUI.Services;

public class FormTypeService : IApplicationFormTypeService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    public FormTypeService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager,)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;

    }

    public string? userId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public ApplicationUser user => _userManager.Users.FirstAsync(u => u.Id == userId);


}
