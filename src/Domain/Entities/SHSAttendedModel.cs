using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineApplicationSystem.Domain.Entities
{
    public record SHSAttendedModel
    {
        [Key]
        public int Id { set; get; }
        public bool AttendedTTU { get; set; }
        public int Applicant { get; set; }

        [ForeignKey("student")]
        public ApplicantModel? ApplicantModel { get; set; }
        public FormerSchoolModel? Name { set; get; }
        public RegionModel? Location { set; get; }
        public string? StartYear { set; get; }
        public string? EndYear { set; get; }



    }
}