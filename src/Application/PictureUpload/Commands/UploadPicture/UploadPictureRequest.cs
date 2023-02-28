using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Domain.Enums;

namespace OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;
/* public record UploadPictureRequest : IRequest
{
    public string? UserId { get; init; }
    public string? FileName { get; init; }

} */
public class UploadPictureRequest : IRequest<int>
{
    public string? UserId { get; init; }
    public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
}