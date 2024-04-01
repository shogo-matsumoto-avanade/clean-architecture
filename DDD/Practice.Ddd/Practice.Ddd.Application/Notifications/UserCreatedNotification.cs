using MediatR;
using Practice.Ddd.Application.Models.UserModels;

namespace Practice.Ddd.Application.Notifications;

public class UserCreatedNotification : INotification
{
    public required IUserModel User { get; set; }
}
