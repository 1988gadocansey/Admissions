using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.PreviousSHSAttended.Commands;
public record DeleteSHSAttendedRequest(int Id) : IRequest;
public class DeleteSHSAttendedCommandHandler : IRequestHandler<DeleteSHSAttendedRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteSHSAttendedCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSHSAttendedRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.SHSAttendedModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.SHSAttendedModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}