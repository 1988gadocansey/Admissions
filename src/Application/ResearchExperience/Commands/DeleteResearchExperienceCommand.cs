using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.ResearchExperience.Commands;
public record DeleteResearchExperienceRequest(int Id) : IRequest;

public class DeleteResearchExperienceCommand : IRequestHandler<DeleteResearchExperienceRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteResearchExperienceCommand(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteResearchExperienceRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.ResearchModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.ResearchModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
