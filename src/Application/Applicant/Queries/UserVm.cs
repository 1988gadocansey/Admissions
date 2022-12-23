using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Applicant.Queries;


public class UserVm
{
    public IList<UserDto> Lists { get; set; } = new List<UserDto>();
}