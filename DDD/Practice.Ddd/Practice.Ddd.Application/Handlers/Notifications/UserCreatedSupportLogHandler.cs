using MediatR;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Services;

namespace Practice.Ddd.Application.Handlers;

/// <summary>
/// User Created Notification Handler : Domain Logger
/// </summary>
/// <remarks>
/// Notification can execute multiple processes with no dependencies. 
/// </remarks>
public class UserCreatedSupportLogHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly IDomainLogger _logger;
    public UserCreatedSupportLogHandler(IDomainLogger logger)
    {
        _logger = logger;        
    }

    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.UserCreated(notification.UserId, notification.UserName, notification.Email);
        return Task.CompletedTask;
    }
}
