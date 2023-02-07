using OnlineApplicationSystem.Application.Common.Interfaces;

namespace OnlineApplicationSystem.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
