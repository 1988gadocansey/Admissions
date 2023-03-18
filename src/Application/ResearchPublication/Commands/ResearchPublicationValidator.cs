using FluentValidation;

namespace OnlineApplicationSystem.Application.ResearchPublication.Commands;

public class ResearchPublicationValidator : AbstractValidator<ResearchPublicationRequest>
{

    public ResearchPublicationValidator()
    {

        RuleFor(v => v.Publication)
            .NotEmpty().WithMessage("Publication  is required.");


    }


}