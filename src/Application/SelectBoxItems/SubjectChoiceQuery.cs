using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

[Authorize]
public record GetSubjectQuery : IRequest<SubjectModel>;

public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;

    public GetSubjectQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository)
    {
        _context = context;
        _applicantRepository = applicantRepository;

    }

    public async Task<SubjectModel> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {

        return await _applicantRepository.Subjects(cancellationToken);
    }
}