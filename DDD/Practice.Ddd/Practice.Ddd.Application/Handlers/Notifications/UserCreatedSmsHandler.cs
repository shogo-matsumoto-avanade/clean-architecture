using MediatR;
using Practice.Ddd.Application.Services;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Handlers;

/// <summary>
/// User Created Notification Handler : Send Sms
/// </summary>
/// <remarks>
/// Notification can execute multiple processes with no dependencies. 
/// </remarks>
public class UserCreatedSmsHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly IMessageBus _messageBus;
    public UserCreatedSmsHandler(IMessageBus logger)
    {
        _messageBus = logger;        
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _messageBus.SendAsync($"Sent SMS of {notification.UserId}:{notification.UserName}");
    }
}
