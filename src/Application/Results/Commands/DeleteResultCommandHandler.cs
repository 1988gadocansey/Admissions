using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Application.Results.Commands;

public record DeleteResultRequest(int Id) : IRequest;

public class DeleteResultCommandHandler : IRequestHandler<DeleteResultRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteResultCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteResultRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.ResultUploadModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.ResultUploadModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
