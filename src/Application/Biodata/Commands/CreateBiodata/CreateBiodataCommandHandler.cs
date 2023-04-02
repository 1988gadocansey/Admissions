using MediatR;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Application.Common.Exceptions;

namespace OnlineApplicationSystem.Application.Biodata.Commands.CreateBiodata;

public class CreateBiodataCommandHandler : IRequestHandler<CreateBiodataRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;

    public CreateBiodataCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime, IIdentityService identityService, IApplicantRepository applicantRepository)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
    }
    public async Task<int> Handle(CreateBiodataRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var region = _context.RegionModels.FirstOrDefault(s => s.Id == request.RegionId);
        var religion = _context.ReligionModels.FirstOrDefault(s => s.Id == request.ReligionId);
        var district = _context.DistrictModels.FirstOrDefault(s => s.ID == request.District);
        var nationality = _context.CountryModels.FirstOrDefault(s => s.ID == request.NationalityId);
        var calender = await _applicantRepository.GetConfiguration();
        // var FormerSchool = _context.FormerSchoolModels.FirstOrDefault(s => s.Id == request.SC);
        var applicantSearch = _context.ApplicantModels.Where(s => s.ApplicationUserId == userId);
        if (applicantSearch.Count() == 0)
        {
            var applicant = new ApplicantModel
            {
                ApplicationUserId = userId,
                ApplicationNumber = ApplicationNumber.Create(Convert.ToInt64(userDetails.FormNo)),
                ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName),
                PreviousName = ApplicantName.Create(request.PreviousName, request.PreviousName, null),
                Title = request.Title,
                Gender = request.Gender,
                Email = EmailAddress.Create(request.Email),
                MaritalStatus = request.MaritalStatus,
                Dob = request.Dob,
                Age = 0,
                Phone = PhoneNumber.Create("+233", request.Phone),
                AltPhone = PhoneNumber.Create("+233", request.AltPhone),
                EmergencyContact = PhoneNumber.Create("+233", request.EmergencyContact),
                Referrals = request.Referrals,
                NationalityId = request.NationalityId,
                Region = region,
                Religion = religion,
                District = district,
                Nationality = nationality,
                Disability = request.Disability,
                DisabilityType = request.DisabilityType,
                IDCard = IDCard.Create(request.NationalIDType.ToString(), request.NationalIDNo),
                ResidentialStatus = request.ResidentialStatus,
                SourceOfFinance = request.SourceOfFinance.ToUpper(),
                Hometown = request.Hometown.ToUpper(),
                GuardianName = request.GuardianName.ToUpper(),
                GuardianOccupation = request.GuardianOccupation.ToUpper(),
                GuardianPhone = PhoneNumber.Create("+233", request.GuardianPhone),
                GuardianRelationship = request.GuardianRelationship,
                SponsorShip = request.SponsorShip,
                SponsorShipCompany = request.SponsorShipCompany,
                SponsorShipCompanyContact = request.SponsorShipCompanyContact,
                SponsorShipLocation = request.SponsorShipLocation,
                YearOfAdmission = calender.Year

            };

            await _context.ApplicantModels.AddAsync(applicant, cancellationToken);
            // await _applicantRepository.UpdateFormNo(cancellationToken);
        }
        else
        {
            var applicant = await _context.ApplicantModels
            .FindAsync(new object[] { request.Id }, cancellationToken);

            if (applicant == null)
            {
                throw new NotFoundException(nameof(ApplicantModel), request.Id);
            }
            applicant.Title = request.Title;
            applicant.ApplicationUserId = _currentUserService.UserId;
            applicant.ApplicationNumber = ApplicationNumber.Create(request.ApplicationNumber);
            applicant.ApplicantName = ApplicantName.Create(request.FirstName, request.LastName, request.OtherName);
            applicant.Title = request.Title;
            applicant.Gender = request.Gender;
            applicant.Email = EmailAddress.Create(request.Email);
            applicant.MaritalStatus = request.MaritalStatus;
            applicant.Dob = request.Dob;
            applicant.Phone = PhoneNumber.Create("+233", request.Phone);
            applicant.AltPhone = PhoneNumber.Create("+233", request.AltPhone);
            applicant.EmergencyContact = PhoneNumber.Create("+233", request.EmergencyContact);
            applicant.Referrals = request.Referrals;
            applicant.NationalityId = request.NationalityId;
            applicant.Region = region;
            applicant.Religion = religion;
            applicant.District = district;
            applicant.Nationality = nationality;
            applicant.Disability = request.Disability;
            applicant.DisabilityType = request.DisabilityType;
            applicant.IDCard = IDCard.Create(request.NationalIDType.ToString(), request.NationalIDNo);
            applicant.ResidentialStatus = request.ResidentialStatus;
            applicant.SourceOfFinance = request.SourceOfFinance.ToUpper();
            applicant.Hometown = request.Hometown.ToUpper();
            applicant.GuardianName = request.GuardianName.ToUpper();
            applicant.GuardianOccupation = request.GuardianOccupation.ToUpper();
            applicant.GuardianPhone = PhoneNumber.Create("+233", request.GuardianPhone);
            applicant.GuardianRelationship = request.GuardianRelationship;
            applicant.SponsorShip = request.SponsorShip;
            applicant.SponsorShipCompany = request.SponsorShipCompany;
            applicant.SponsorShipCompanyContact = request.SponsorShipCompanyContact;
            applicant.SponsorShipLocation = request.SponsorShipLocation;
            await _context.ApplicantModels.AddAsync(applicant, cancellationToken);

        }
        await _context.SaveChangesAsync(cancellationToken);
        // go to issue and update biodata done as true
        var applicantIssues = _context.ApplicantIssueModels.FirstOrDefault(u => u.ApplicantModelId == _currentUserService.UserId);
        if (applicantIssues != null)
        {
            applicantIssues.Biodata = true;
            _context.ApplicantIssueModels.Update(applicantIssues);
        }
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result == 1)
        {
            return 200;
        }
        return 500;
    }
}