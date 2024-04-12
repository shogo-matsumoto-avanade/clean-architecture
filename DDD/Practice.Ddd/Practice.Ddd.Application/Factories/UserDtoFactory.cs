using Practice.Ddd.Application.Models;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Factories;

public static class UserDtoFactory
{
    public static UserDto Create(User user)
    {
        return new UserDto(user);
    }
}
