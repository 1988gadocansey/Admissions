using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;

public class UploadDocumentRequest : IRequest<int>
{
    public string? UserId { get; init; }
    public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
}