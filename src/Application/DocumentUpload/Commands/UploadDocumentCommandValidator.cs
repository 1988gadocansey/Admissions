using FluentValidation;
using MediatR;
using OnlineApplicationSystem.Application.Common.Dtos;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;
public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentRequest>
{
    public UploadDocumentCommandValidator()
    {
        RuleFor(v => v.Files)
            .Must(FilesNotEmpty)
            .WithMessage("File cannot be empty");

        RuleFor(v => v.Files)
            .Must(IsValidContentType)
            .WithMessage("Invalid file type. Only '.pdf' and '.docx' files are allowed");
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
        var validContentTypes = new string[] { "application/pdf", "application/docx" };

        return files.All(file => validContentTypes.Contains(file.ContentType));
    }
}