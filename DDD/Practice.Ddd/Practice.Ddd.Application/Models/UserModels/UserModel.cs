using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Models.UserModels;

internal class UserModel : IUserModel
{
    public UserModel(User user)
    {
        UserName = user.UserName;
    }
    public UserModel(string userName)
    {
        UserName = userName;
    }
    public string UserName { get; private set; }
}
