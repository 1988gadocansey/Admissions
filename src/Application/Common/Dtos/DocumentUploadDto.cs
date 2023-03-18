using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;



public record DocumentUploadDto
{

    public int Id { get; set; }
    public int Applicant { set; get; }
    public string? Name { set; get; }
    public string? Type { set; get; }

}