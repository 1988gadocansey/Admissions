using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Infrastructure.Identity;

namespace OnlineApplicationSystem.WebUI.Services;

public class FormTypeService : IApplicationFormTypeService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    public FormTypeService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;

    }

    public string? userId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public UserDto user => _userManager.Users
    .Select(b =>
        new UserDto()
        {
            Id = b.Id,
            UserName = b.UserName,
            FormCompleted = b.FormCompleted,
            Finalized = b.Finalized,
            SoldBy = b.SoldBy,
            Branch = b.Branch,
            Started = b.Started,
            Year = b.Year,
            Pin = b.Pin,
            PictureUploaded = b.PictureUploaded,
            FormNo = b.FormNo,
            FullName = b.FullName,
            ResultUploaded = b.ResultUploaded,
            Admitted = b.Admitted,
            LastLogin = b.LastLogin,
            Type = b.Type,
            Category = b.Category,
            Foriegn = b.Foriegn,
        }).FirstOrDefault(u => u.Id == userId);

}
