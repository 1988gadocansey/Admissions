using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetSubjectQuery : IRequest<IEnumerable<SubjectDto>>;

public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, IEnumerable<SubjectDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetSubjectQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<IEnumerable<SubjectDto>> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        var data = await _applicantRepository.Subjects(cancellationToken);
        return data;
    }

}