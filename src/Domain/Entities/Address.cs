using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{

    public class Address
    {
        [Key] public int Id { set; get; }
        public string Street {  set; get; }
        public string HouseNumber { set; get;}
        public string City {  set; get; }
        public string GPRS {  set; get; }
        public string Box {  set; get; }
        public int ApplicantModelID { set; get; }
        private ICollection<ApplicantModel?> ApplicantModel { get; set; }


    }
}