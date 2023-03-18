using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.UniversityAttended.Commands;

public record DeleteUniversityAttendedRequest(int Id) : IRequest;

public class DeleteUniversityAttendedCommandHandler : IRequestHandler<DeleteUniversityAttendedRequest>
{
    private readonly IApplicationDbContext _context;

    public DeleteUniversityAttendedCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUniversityAttendedRequest request, CancellationToken cancellationToken)
    {
        var entity = await _context.UniversityAttendedModels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ResultUploadModel), request.Id);
        }

        _context.UniversityAttendedModels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}