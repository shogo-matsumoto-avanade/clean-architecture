using Practice.Ddd.Domain.Users;
using System.Security.Cryptography.X509Certificates;

namespace Practice.Ddd.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    public void Create(User user)
    {
        throw new NotImplementedException();
    }

    public User? Find(UserId userId)
    {
        throw new NotImplementedException();
    }
}
