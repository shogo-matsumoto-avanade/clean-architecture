using MediatR;

namespace Practice.Ddd.Application.Requests.Notifications;

public class UserCreatedEvent : INotification
{
    public string UserName { get; private set; }
    public string Email { get; private set; }

    public UserCreatedEvent(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }
}
