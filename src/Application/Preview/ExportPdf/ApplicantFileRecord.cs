using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Domain.Enums;

namespace OnlineApplicationSystem.Application.Preview;

public class ExportApplicantFileRecord : IMapFrom<ApplicantModel>

{
    public long ApplicationNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string OtherName { get; init; }
    public Gender Gender { get; init; }
    public DateOnly Dob { get; init; }
    public Title Title { get; init; }
    public MaritalStatus? MaritalStatus { get; set; } = Domain.Enums.MaritalStatus.Single;
    public string Phone { get; init; }
    public string? AltPhone { get; init; }
    public string? Email { get; init; }
    public string? PostGPRS { get; init; }
    public string? EmergencyContact { get; init; }
    public string? Hometown { get; init; }
    public int? District { get; init; }
    public IDCards? NationalIDType { get; init; }
    public int? RegionId { get; init; }
    public int? NationalityId { get; init; }
    public bool? ResidentialStatus { get; init; }
    public string? GuardianName { get; init; }
    public string? GuardianPhone { get; init; }
    public string? GuardianOccupation { get; init; }
    public string? GuardianRelationship { get; init; }
    public bool? Disability { get; init; }
    public Disability? DisabilityType { get; init; }
    public string? SourceOfFinance { get; init; }
    public int? ReligionId { get; init; }
    public string? Denomination { get; init; }
    public string? Referrals { get; init; }
    public Session? EntryMode { get; init; }
    public string? FirstQualification { get; init; }
    public string? SecondQualification { get; init; }
    public string? ProgrammeStudied { get; init; }
    public string? FormerSchool { get; init; }
    public int? FormerSchoolNewId { get; init; }
    public int? ProgrammeAdmittedId { get; init; }
    public int? LastYearInSchool { get; init; }
    public bool? Awaiting { get; init; }
    public int? Grade { get; init; }
    public string? PreferedHall { get; init; }
    public bool? Elligible { get; init; }
    public bool? Admitted { get; init; }
    public int? AdmittedBy { get; init; }
    public string? AdmissionType { get; init; }
    public string? leveladmitted { get; init; }
    public int? FirstChoiceId { get; init; }
    public int? SecondChoiceId { get; init; }
    public int? ThirdChoiceId { get; init; }
    public bool? SponsorShip { get; init; }
    public string? SponsorShipCompany { get; init; }
    public string? SponsorShipLocation { get; init; }
    public string? SponsorShipCompanyContact { get; init; }


}
