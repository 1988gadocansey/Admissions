using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Application.Common.Exceptions;

namespace OnlineApplicationSystem.Application.Address.Commands;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;

    public CreateAddressCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }
    public async Task<int> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var applicant = _context.ApplicantModels.FirstOrDefault(a => a.ApplicationUserId == userId);

        if (request.Id == 0 || request.Id == null)
        {
            var address = new AddressModel
            {
                Street = request.Street,
                City = request.City,
                Box = request.Box,
                HouseNumber = request.HouseNumber,
                GPRS = request.GPRS,
                Applicant = applicant
            };
            await _context.AddressModels.AddAsync(address);


        }
        else
        {
            var address = _context.AddressModels.FirstOrDefault(a => a.Applicant == applicant);
            address.Street = request.Street;
            address.City = request.City;
            address.HouseNumber = request.HouseNumber;
            address.Box = request.Box;
            address.GPRS = request.GPRS;
            _context.AddressModels.Update(address);
        }
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result == 1)
        {
            return 200;
        }
        return 500;

    }
}