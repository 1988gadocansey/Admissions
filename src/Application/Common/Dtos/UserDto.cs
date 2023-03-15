using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public class UserDto
{
    public string? Id { get; init; }
    public string? UserName { get; init; }

    public string? FormNo { get; set; }
    public int? Started { get; set; }
    public string? FullName { get; set; }
    public string? Type { get; set; }
    public string? SoldBy { set; get; }
    public string? Category { set; get; }
    public int? FormCompleted { set; get; }
    public int? PictureUploaded { set; get; }
    public int? Finalized { set; get; }
    public string? Year { get; set; }
    public bool? ResultUploaded { get; set; }
    public bool? Admitted { get; set; }
    public bool? Foriegn { get; set; }

    public DateTime? LastLogin { set; get; }

}