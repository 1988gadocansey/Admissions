using MediatR;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;

public record SHSAttendedRequest : IRequest<int>
{
    public int Id { set; get; }
    public bool AttendedTTU { get; set; }
    public string? Name { set; get; }
    public int? Location { set; get; }
    public int? Applicant { set; get; }
    public string? StartYear { set; get; }
    public string? EndYear { set; get; }

}