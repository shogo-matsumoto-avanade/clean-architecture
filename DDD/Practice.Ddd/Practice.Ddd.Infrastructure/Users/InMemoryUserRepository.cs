using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Infrastructure.Users;

public class InMemoryUserRepository : IUserRepository
{
    public void Create(User user)
    {
        //throw new NotImplementedException();
    }

    public User? Find(UserId userId)
    {
        if (!userId.Equals(new UserId("test"))) return null;
        return new User("test-id", "first name", "last name", "xxxx@xxxx");
    }
}
