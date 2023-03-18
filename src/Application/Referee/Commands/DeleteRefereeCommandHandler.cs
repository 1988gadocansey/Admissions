using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Referee.Commands;
public record DeleteeRefereeRequest(int Id) : IRequest;

public class DeleteRefereeCommandHandler : IRequestHandler<DeleteeRefereeRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteRefereeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteeRefereeRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.RefereeModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.RefereeModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
