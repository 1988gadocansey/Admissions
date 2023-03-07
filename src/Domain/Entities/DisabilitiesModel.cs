using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities;
public record DisabilitiesModel
{
    [Key]
    public int Id { set; get; }
    public string Name { set; get; }


}
