using AutoMapper;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview;

namespace OnlineApplicationSystem.Application.Address.Queries;

public record GetAddressQuery : IRequest<AddressDto>;

public class GetAddressQueryQueryHandler : IRequestHandler<GetAddressQuery, AddressDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetAddressQueryQueryHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _mapper = mapper;
        _identityService = identityService;

    }

    public async Task<AddressDto> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {

        var applicantDetails = await _applicantRepository.GetApplicantForUser(_currentUserService.UserId, cancellationToken);

        return await _applicantRepository.GetAddresses(applicantDetails.Id, cancellationToken);

    }

}
