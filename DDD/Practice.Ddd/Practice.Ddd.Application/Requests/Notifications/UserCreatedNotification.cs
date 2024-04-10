using MediatR;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Requests.Notifications;

public class UserCreatedNotification : INotification
{
    public UserId UserId { get; private set; }
    public string UserName { get; private set; }
    public Email Email { get; private set; }

    public UserCreatedNotification(UserId id, string userName, Email email)
    {
        UserId = id;
        UserName = userName;
        Email = email;
    }
}
