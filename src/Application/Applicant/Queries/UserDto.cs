using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Applicant.Queries;
public class UserDto : IMapFrom<UserVm>
{
    public string? UserId;
    public int ApplicationNumber { get; set; }
    public string FormType { get; set; }
    public bool completedForm { get; set; }
    public bool startedForm { get; set; }
    public bool pictureUpload { get; set; }
    public bool academicYear { get; set; }

}