using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;
/**
 *  fluent validator used here
 */
public class AcademicExperienceValidator: AbstractValidator<AcademicExperienceModel>
{
    public AcademicExperienceValidator()
    {
        RuleFor(x => x.Certificate).NotEmpty().WithMessage("Company is required");
        RuleFor(x => x.From).NotEmpty().WithMessage("Start date required");
        //RuleFor(x => x.To).NotEmpty().WithMessage("Provide atleast a single Category");
        RuleFor(x => x.InstitutionAddress).NotEmpty().WithMessage("Institution address is required");
    }
}