using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;

namespace OnlineApplicationSystem.Application.Results.Commands;
public class CreateResultCommandValidator : AbstractValidator<CreateResultRequest>
{

    private readonly IApplicationDbContext _context;
    public CreateResultCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        /* RuleFor(v => v.GradeID)
            .NotEmpty().WithMessage("Grade is required.");
        RuleFor(v => v.SubjectID)
      .NotEmpty().WithMessage("Subject is required.")
      .MustAsync(BeUniqueSubject).WithMessage("The specified subject  already exists.");
        ;

        RuleFor(v => v.ExamType)
      .NotEmpty().WithMessage("Exam type is required.");

        RuleFor(v => v.Center)
        .NotEmpty().WithMessage("Center is required.");

        RuleFor(v => v.Year)
        .NotEmpty().WithMessage("Year is required.");

        RuleFor(v => v.Sitting)
       .NotEmpty().WithMessage("Sitting is required.");

        RuleFor(v => v.Month)
       .NotEmpty().WithMessage("Month is required.");

        RuleFor(v => v.IndexNo)
       .NotEmpty().WithMessage("Index No is required."); */

    }

    public async Task<bool> BeUniqueSubject(int Subject, CancellationToken cancellationToken)
    {
        return await _context.ResultUploadModels
            .AllAsync(l => l.Subject.Id != Subject, cancellationToken);
    }
}
