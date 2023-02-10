using MediatR;
using OnlineApplicationSystem.Domain.Enums;

namespace OnlineApplicationSystem.Application.PictureUpload.UploadPicture;
public record UploadPictureRequest : IRequest<int>
{
    public long ApplicationNumber { get; init; }
    public string? FileName { get; init; }

}