using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;
public class SHSAttendedCommandValidator : AbstractValidator<SHSAttendedRequest>
{

    private readonly IApplicationDbContext _context;
    public SHSAttendedCommandValidator(IApplicationDbContext context)
    {
        /*    _context = context;
           RuleFor(x => x.StartYear).NotEmpty();
           RuleFor(x => x.EndYear).NotEmpty();
           RuleFor(x => x).Must(x => x.EndYear > x.StartYear)
                   .WithMessage("start date must be less than end date"); */

    }


}
