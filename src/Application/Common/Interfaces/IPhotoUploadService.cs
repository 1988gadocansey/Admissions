using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface IPhotoUploadService
{
    string UserId { get; set; }
    Task<UrlsDto> UploadAsync(ICollection<FileDto> files);
    Task<int> SendFileToServer(string applicant, IEnumerable<FileDto> files, CancellationToken cancellationToken);

}