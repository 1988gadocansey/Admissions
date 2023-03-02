using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetReligionQuery : IRequest< IEnumerable<ReligionDto>>;

public class GetReligionQueryHandler : IRequestHandler<GetReligionQuery,  IEnumerable<ReligionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetReligionQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<ReligionDto>> Handle(GetReligionQuery request, CancellationToken cancellationToken)
    {
            var data = await _applicantRepository.Religions(cancellationToken);
        return data;
    }

}