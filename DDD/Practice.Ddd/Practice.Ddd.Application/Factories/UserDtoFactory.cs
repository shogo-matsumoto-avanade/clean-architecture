using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Factories;

public static class UserDtoFactory
{
    public static IUserDto Create(User? user)
    {
        if (user is null)
        {
            return new NullUserDto();
        }
        return new UserDto(user);
    }
}
