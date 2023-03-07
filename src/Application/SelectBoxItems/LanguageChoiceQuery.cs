using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetLanguageQuery : IRequest<IEnumerable<LanguageDto>>;

public class GetLanguageQueryHandler : RequestHandler<GetLanguageQuery, IEnumerable<LanguageDto>>
{
    private static readonly string[] Summaries = new[]
    {
        "DANGME", "EWE", "AKAN", "DAGAARE", "DAGBANE", "NZEMA", "KASEM", "GONJA", "GA", "HAUSA"
    };

    protected override IEnumerable<LanguageDto> Handle(GetLanguageQuery request)
    {
        return Enumerable.Range(1, 10).Select(index => new LanguageDto
        {

            Name = Summaries[index]
        });
    }
}
