using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities;

public class UniversityModel
{
    [Key]
    public int Id { set; get; }

    public string University { set; get; }
    public string Location { get; set; }
}