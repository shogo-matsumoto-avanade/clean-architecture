using MediatR;
using Microsoft.Extensions.Logging;
using Practice.Ddd.Application.Requests.Notifications;

namespace Practice.Ddd.Application.Handlers;

/// <summary>
/// User Created Notification Handler : Send Sms
/// </summary>
/// <remarks>
/// Notification can execute multiple processes with no dependencies. 
/// </remarks>
public class UserCreatedSmsHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedSmsHandler> _logger;
    public UserCreatedSmsHandler(ILogger<UserCreatedSmsHandler> logger)
    {
        _logger = logger;        
    }

    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Send Sms
        _logger.LogInformation("Sent SMS of {user}", notification.UserName);
        return Task.CompletedTask;
    }
}
