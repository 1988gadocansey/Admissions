using System.ComponentModel.DataAnnotations;

namespace OnlineApplicationSystem.Domain.Entities;


public class AddressModel
{
    [Key] public int Id { set; get; }
    public string? Street { set; get; }
    public string? HouseNumber { set; get; }
    public string? City { set; get; }
    public string? GPRS { set; get; }
    public string? Box { set; get; }
    // public int ApplicantModel { set; get; }
    public virtual ApplicantModel Applicant { get; set; }
    //  private IEnumerable<ApplicantModel>? Applicants { get; set; }


}