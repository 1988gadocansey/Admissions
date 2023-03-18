using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.DocumentUpload.Commands;

public record DeleteDocumentUploadRequest(int Id) : IRequest;

public class DeleteDocumentUploadCommandHandler : IRequestHandler<DeleteDocumentUploadRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteDocumentUploadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteDocumentUploadRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.DocumentUploadModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(DocumentUploadModel), request.Id);
        }

        _context.DocumentUploadModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        // lets delete the files

        return Unit.Value;
    }
}
