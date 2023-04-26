using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.Security;
using MediatR;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace OnlineApplicationSystem.Application.SelectBoxItems;

public class GetProgrammeByIdQuery : IRequest<ProgrammeDto>
{
    public int Id { get; set; }
    public class GetProgrammeByIdQueryHandler : IRequestHandler<GetProgrammeByIdQuery, ProgrammeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        public GetProgrammeByIdQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, IMapper mapper)
        {
            _context = context;
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }
        public async Task<ProgrammeDto> Handle(GetProgrammeByIdQuery query, CancellationToken cancellationToken)
        {

            var programme = await _context.ProgrammeModels.FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

            return _mapper.Map<ProgrammeDto>(programme);
        }
    }
}