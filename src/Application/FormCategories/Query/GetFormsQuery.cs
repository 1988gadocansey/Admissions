using MediatR;
using OnlineApplicationSystem.Domain.Enums;
namespace OnlineApplicationSystem.Application.FormCategories.Query;
public record GetFormsQuery : IRequest<IEnumerable<ApplicationType>>;

public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, IEnumerable<ApplicationType>>
{
    public async Task<IEnumerable<ApplicationType>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
    {
        var formTypes = Enum.GetValues<ApplicationType>();
        return formTypes;
    }

}