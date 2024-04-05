using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Models.UserModels;

internal class UserModel : IUserModel
{
    public UserModel(User user)
    {
        UserName = user.UserName;
        Email = user.Email;
    }
    public UserModel(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }
    public string UserName { get; private set; }

    public string Email { get; private set; }
}
