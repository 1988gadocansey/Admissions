using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record DisabilityChoiceQuery : IRequest<IEnumerable<DisabilitiesDto>>;

public class DisabilityChoiceQueryHandler : RequestHandler<DisabilityChoiceQuery, IEnumerable<DisabilitiesDto>>
{
    private static readonly string[] Summaries = new[]
    {
        "DEAF", "DUMB", "DEAF and DUMB", "BLIND (1 Eye)", "DEAF (1 Ear)", "CRIPPLED", "AMPUTEE", "BLIND"
    };
    //IEnumerable<string> strings = new[] { "a", "b", "c" };

    protected override IEnumerable<DisabilitiesDto> Handle(DisabilityChoiceQuery request)
    {
        return Enumerable.Range(1, 10).Select(index => new DisabilitiesDto
        {

            Name = Summaries[index]
        });
    }
}
