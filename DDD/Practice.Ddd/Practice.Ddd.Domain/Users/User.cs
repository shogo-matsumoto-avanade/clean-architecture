
namespace Practice.Ddd.Domain.Users;

public class User
{
    /// <summary>
    /// Constractor
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userName"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public User(string userId, string userName)
    {
        ArgumentNullException.ThrowIfNull(userId);
        UserId = new UserId(userId);
        UserName = userName;
    }

    public UserId UserId { get; private set; }

    public string UserName { get; private set; }
}
