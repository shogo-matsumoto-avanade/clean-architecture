using Practice.Ddd.Application.Models.UserModels;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Factories;

public static class UserModelFactory
{
    public static IUserModel Create(User? user)
    {
        if (user is null)
        {
            return new NullUserModel();
        }
        return new UserModel(user);
    }

    public static IUserModel Create(string userName, string email)
    {
        if (userName is null)
        {
            return new NullUserModel();
        }
        return new UserModel(userName, email);
    }
}
