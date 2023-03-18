using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.WorkingExperience.Commands;
public record DeleteWorkingExperienceRequest(int Id) : IRequest;

public class DeleteWorkingExperienceCommandHandler : IRequestHandler<DeleteWorkingExperienceRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkingExperienceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteWorkingExperienceRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkingExperienceModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkingExperienceModel), request.Id);
        }

        _context.WorkingExperienceModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}