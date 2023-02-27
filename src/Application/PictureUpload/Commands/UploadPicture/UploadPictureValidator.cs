using FluentValidation;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.PictureUpload.Commands.UploadPicture;
public class UploadPictureValidator : AbstractValidator<UploadPictureRequest>
{
    public UploadPictureValidator()
    {
        RuleFor(v => v.Files)
            .Must(FilesNotEmpty)
            .WithMessage("File cannot be empty");

        RuleFor(v => v.Files)
            .Must(IsValidContentType)
            .WithMessage("Invalid file type. Only '.jpg' and '.jpeg' files are allowed");


    }

    private static bool FilesNotEmpty(ICollection<FileDto>? files)
    {
        if (files == null || files.Count == 0)
        {
            return false;
        }

        return files.All(file => file.Content.Length != 0);
    }
    
    private static bool IsValidContentType(ICollection<FileDto> files)
    {
        var validContentTypes = new string[] { "image/jpeg", "image/jpg" };

        return files.All(file => validContentTypes.Contains(file.ContentType));
    }
}