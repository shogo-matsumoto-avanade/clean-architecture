using MediatR;
using Microsoft.Extensions.Logging;
using Practice.Ddd.Application.Requests.Notifications;
using Practice.Ddd.Application.Services;

namespace Practice.Ddd.Application.Handlers;

/// <summary>
/// User Created Notification Handler : Send Sms
/// </summary>
/// <remarks>
/// Notification can execute multiple processes with no dependencies. 
/// </remarks>
public class UserCreatedEmailHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly IMessageBus _messageBus;

    public UserCreatedEmailHandler(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task Handle(
        UserCreatedEvent notification, 
        CancellationToken cancellationToken)
    {
        await _messageBus.SendAsync($"Sent Email to {notification.Email}");
    }
}
