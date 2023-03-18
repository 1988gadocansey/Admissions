using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.ResearchPublication.Commands;
public record DeleteResearchPublicationRequest(int Id) : IRequest;

public class DeleteResearchPublicationCommand : IRequestHandler<DeleteResearchPublicationRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteResearchPublicationCommand(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteResearchPublicationRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.ResearchPublicationModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.ResearchPublicationModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
