using AutoMapper;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record DisabilityChoiceQuery : IRequest<IEnumerable<string>>;

public class DisabilityChoiceQueryHandler : RequestHandler<DisabilityChoiceQuery, IEnumerable<string>>
{
    private readonly IMapper _mapper;

    public DisabilityChoiceQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
   
    
    //IEnumerable<string> strings = new[] { "a", "b", "c" };

    protected override  IEnumerable<string> Handle (DisabilityChoiceQuery request)
    {
        var Disabilities = new[]
        {
            "DEAF", "DUMB", "DEAF and DUMB", "BLIND (1 Eye)", "DEAF (1 Ear)", "CRIPPLED", "AMPUTEE", "BLIND"
        };
        var data = Disabilities.Select(cust => cust);
       // var dataMapped = _mapper.Map<DisabilitiesDto>(data);
       return data;
    }
}
