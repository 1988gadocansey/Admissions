using MediatR;
using Microsoft.Extensions.Logging;
using OnlineApplicationSystem.Domain.Events;
namespace OnlineApplicationSystem.Domain.Events;

public class BioDataCreatedEventHandler : INotificationHandler<BiodataStartedEvent>
{
    private readonly ILogger<BioDataCreatedEventHandler> _logger;

    public BioDataCreatedEventHandler(ILogger<BioDataCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BiodataStartedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("OnlineApplicationSystem Biodata started : {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }


}