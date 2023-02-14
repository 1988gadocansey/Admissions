using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities
{
    public class ApplicantModel : BaseAuditableEntity
    {
        public ApplicantModel()
        {
        }
        public ApplicationNumber ApplicationNumber { get; set; }
        public Title Title { set; get; }
        public ApplicantName ApplicantName { get; set; }
        public ApplicantName? PreviousName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public MaritalStatus? MaritalStatus { get; set; } = Enums.MaritalStatus.Single;
        public PhoneNumber Phone { get; private set; }
        public PhoneNumber? AltPhone { get; set; }
        public EmailAddress Email { get; set; }
        public string? PostGPRS { get; set; }
        public PhoneNumber? EmergencyContact { get; private set; }
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
        public PhoneNumber GuardianPhone { get; private set; }
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
        public string? FirstQualification { get; set; }
        public string? SecondQualification { get; set; }
        public string? ProgrammeStudied { get; set; }
        public string? FormerSchool { get; set; }
        public int? FormerSchoolNewId { get; set; }
        public virtual FormerSchoolModel? FormerSchoolNew { get; set; }
        public int? ProgrammeAdmittedId { get; set; }
        public int? LastYearInSchool { get; set; }
        public bool? Awaiting { get; set; }
        public int? Grade { get; set; }
        public string? YearOfAdmission { get; set; }
        public string? PreferedHall { get; set; }
        public string? Results { get; set; }
        public string? ExternalHostel { get; set; }
        public bool? Elligible { get; set; }
        public bool? Admitted { get; set; }
        public int? AdmittedBy { get; set; }
        public DateTime? DateAdmitted { get; set; }
        public AdmissionType? AdmissionType { get; set; } = Enums.AdmissionType.Regular;
        public string? leveladmitted { get; set; }
        public string? SectionAdmitted { get; set; }
        public int? HallAdmitted { get; set; }
        public string? RoomNo { get; set; }
        // public string? Status { get; set; }
        public ApplicationStatus? Status => ApplicationStatus.Applicant;
        public bool? SMSSent { get; set; }
        public bool? LetterPrinted { get; set; }
        public int? FirstChoiceId { get; set; }
        public int? SecondChoiceId { get; set; }
        public int? ThirdChoiceId { get; set; }
        public bool? FeePaying { get; set; }
        public bool? ReportedInSchool { get; set; }
        public Money? FeesPaid { get; set; }
        public Money? HallFeesPaid { get; set; }
        public bool? Reported { get; set; }
        public bool? SponsorShip { get; set; }
        public string? SponsorShipCompany { get; set; }
        public string? SponsorShipLocation { get; set; }
        public string? SponsorShipCompanyContact { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicantName ChangeName(ApplicantName Name)
        {
            if (object.ReferenceEquals(Name, null))
                throw new ArgumentException("Name must have value", nameof(Name));
            return Name;
        }
        /*[Display(Name = "Full Name")]
        public string FullName => Title +" "+ LastName + ", " + FirstName + " "+ MiddleName;
        */

        private IList<ProgrammeModel> Programme { get; set; }
        private IList<ResultUploadModel> ResultUpload { get; set; }
        private IList<WorkingExperienceModel?> WorkingExperience { get; set; }
        private IList<AcademicExperienceModel?> AcademicExperience { get; set; }
        private IList<DocumentUploadModel?> DocumentUpload { get; set; }
        private IList<RefereeModel?> RefereeModel { get; set; }
        private IList<Address?> Address { get; set; }
        private IList<LanguageModel?> LanguageModels { get; set; }
        private IList<SMSModel> Sms { get; set; }
        private IList<ApplicantIssueModel>? ApplicantIssue { get; set; }
        private IList<ResearchModel>? ResearchModels { get; set; }
        private IList<ResearchPublicationModel>? ResearchPublications { get; set; }

    }
}
