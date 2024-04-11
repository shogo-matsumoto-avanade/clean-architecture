using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Models.UserModels;

internal class UserDto : IUserDto
{
    public UserDto(User user)
    {
        UserName = user.UserName;
        Email = user.Email.ToString();
    }
    public string UserName { get; private set; }

    public string Email { get; private set; }
}
