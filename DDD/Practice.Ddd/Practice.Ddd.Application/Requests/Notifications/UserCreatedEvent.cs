using MediatR;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Requests.Notifications;

public class UserCreatedEvent : INotification
{
    public UserId UserId { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }

    public UserCreatedEvent(UserId id, string userName, string email)
    {
        UserId = id;
        UserName = userName;
        Email = email;
    }
}
