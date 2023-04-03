using AutoMapper;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Domain.ValueObjects;

namespace OnlineApplicationSystem.Application.Common.ViewModels;

public class ApplicantVm : IMapFrom<ApplicantModel>
{

    public int Id { get; init; }
    public ApplicationNumber ApplicationNumber { get; set; }
    public Title Title { set; get; }
    public ApplicantName ApplicantName { get; set; }
    public ApplicantName? PreviousName { get; set; }

    public DateOnly Dob { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public MaritalStatus? MaritalStatus { get; set; } = Domain.Enums.MaritalStatus.Single;
    public PhoneNumber Phone { get; set; }
    public PhoneNumber? AltPhone { get; set; }
    public EmailAddress Email { get; set; }
    public string? PostGPRS { get; set; }
    public PhoneNumber? EmergencyContact { get; set; }
    public string? Hometown { get; set; }
    public int? DistrictId { get; set; }
    public virtual DistrictModel? District { get; set; }
    public virtual HallModel? Hall { get; set; }
    // public IDCards NationalIDType { get; set; }
    // public string NationalIDNo { get; set; }

    public IDCard? IDCard { get; set; }
    public int? RegionId { get; set; }
    public virtual RegionModel? Region { get; set; }
    public int? NationalityId { get; set; }
    public virtual CountryModel? Nationality { get; set; }
    public bool? ResidentialStatus { get; set; }
    public string? GuardianName { get; set; }
    public PhoneNumber GuardianPhone { get; set; }
    public string? GuardianOccupation { get; set; }
    public string? GuardianRelationship { get; set; }
    public bool? Disability { get; set; }
    public Disability? DisabilityType { get; set; }
    public string? SourceOfFinance { get; set; }
    public int? ReligionId { get; set; }
    public virtual ReligionModel? Religion { get; set; }
    public string? Denomination { get; }
    public string? Referrals { get; set; }
    public Session? EntryMode { get; set; }
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
    public int? FirstChoice { get; init; }
    public int? SecondChoice { get; init; }
    public int? ThirdChoice { get; init; }
    public bool? SponsorShip { get; init; }
    public string? SponsorShipCompany { get; init; }
    public string? SponsorShipLocation { get; init; }
    public string? SponsorShipCompanyContact { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicantModel, ApplicantVm>()
            .ForMember(d => d.FormerSchool, opt => opt.MapFrom(s => s.FormerSchoolNew.Name))
            .ForMember(d => d.Region, opt => opt.MapFrom(s => s.Region.Name));
    }


}