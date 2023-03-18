using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;

public class UploadDocumentRequest : IRequest<int>
{
    public string? UserId { get; init; }
    public int Id { get; set; }
    public int Applicant { set; get; }
    public string? Name { set; get; }
    public string? Type { set; get; }
    public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
}