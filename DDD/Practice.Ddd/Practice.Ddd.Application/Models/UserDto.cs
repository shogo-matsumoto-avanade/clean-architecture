using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Models;

public class UserDto(User user)
{
    public string UserName { get; private set; } = user.UserName;

    public string Email { get; private set; } = user.Email.Value;
}
