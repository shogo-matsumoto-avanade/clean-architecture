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
public class UserCreatedEmailHandler : INotificationHandler<UserCreatedNotification>
{
    private readonly ILogger<UserCreatedEmailHandler> _logger;
    public UserCreatedEmailHandler(ILogger<UserCreatedEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        // Send Email
        _logger.LogInformation("Sent Email to {user}@xxx.com", notification.User.UserName);
        return Task.CompletedTask;
    }
}
