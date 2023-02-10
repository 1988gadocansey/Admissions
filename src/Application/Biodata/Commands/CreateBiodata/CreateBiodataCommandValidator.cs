using OnlineApplicationSystem.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.Biodata.CreateBiodata;

public class CreateBiodataCommandValidator : AbstractValidator<CreateBiodataRequest>
{
    private readonly IApplicationDbContext _context;

    public CreateBiodataCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
        RuleFor(v => v.LastName)
       .NotEmpty().WithMessage("Last Name is required.")
       .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
        RuleFor(v => v.Email)
          .EmailAddress().WithMessage("A valid email is required")
          .MaximumLength(200).WithMessage("Email must not exceed 100 characters.");

        RuleFor(v => v.NationalIDNo)
           .NotEmpty().WithMessage("National ID No is required.")
           .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
        .MustAsync(BeUniqueNationalIDNo).WithMessage("The specified ID already exists.");
    }

    public async Task<bool> BeUniqueNationalIDNo(string NationalIDNo, CancellationToken cancellationToken)
    {
        return await _context.ApplicantModel
            .AllAsync(l => l.NationalIDNo != NationalIDNo, cancellationToken);
    }
}
