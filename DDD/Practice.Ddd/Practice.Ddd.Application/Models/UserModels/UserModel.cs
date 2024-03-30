using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Models.UserModels;

internal class UserModel : IUserModel
{
    public UserModel(User user)
    {
        UserName = user.UserName;
    }
    public string UserName { get; private set; }
}
