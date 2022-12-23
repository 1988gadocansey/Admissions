using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public class LanguageModel
    {
        
        [Key] public int Id { set; get; }
        public string Name { set; get; }
        public int ApplicantModelID { set; get; }
        private ICollection<ApplicantModel?> ApplicantModel { get; set; }


        public LanguageModel()
        {

        }
    }
}