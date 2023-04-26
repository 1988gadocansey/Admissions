using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.User.Queries;
using AutoMapper;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IApplicantRepository _applicantRepository;

    private readonly IMapper _mapper;
    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService, IMapper mapper, IApplicantRepository applicantRepository)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _mapper = mapper;
        _applicantRepository = applicantRepository;
    }

    async Task<string?> IIdentityService.GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    async Task<(Result Result, string UserId)> IIdentityService.CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    async Task<bool> IIdentityService.IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }



    async Task<bool> IIdentityService.AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    async Task<Result> IIdentityService.DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
    public async Task<UserDto> GetApplicationUserDetails(string? userId, CancellationToken cancellationToken)
    {
        // now lets generate application number give the application and update his status as started
        var Formno = await _applicantRepository.GetFormNo();
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        var calender = await _applicantRepository.GetConfiguration();
        user.FormNo = calender.Year + Formno;
        user.Started = 1;
        if (user.PictureUploaded == 0)
        {
            await _userManager.UpdateAsync(user);
            await _applicantRepository.UpdateFormNo(cancellationToken);
        }
        else if (user.Admitted)
        {
            // put admission letter and fees info here
        }
        var userdetails = await _userManager.Users.Select(b =>
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
        }).FirstOrDefaultAsync(a => a.Id == userId, cancellationToken: cancellationToken);
        return userdetails;
    }

    public async Task UpdateApplicationPictureStatus(string? userId, ICollection<FileDto> photo, CancellationToken cancellationToken)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.PictureUploaded = 1;
            await _userManager.UpdateAsync(user);
        }
    }
    public async Task<bool> ChangeApplicantFormType(string? userId, string? formType)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.Type = formType;
            await _userManager.UpdateAsync(user);
            return true;
        }
        return false;
    }
    public async Task Finalized(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.Finalized = 1;
            user.FormCompleted = 1;
            await _userManager.UpdateAsync(user);
        }
    }
}
