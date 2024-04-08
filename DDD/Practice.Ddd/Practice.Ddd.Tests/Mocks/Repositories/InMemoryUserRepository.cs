using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Tests.Mocks.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly IDictionary<UserId, User> _users = new Dictionary<UserId, User>();

    public InMemoryUserRepository()
    {
        _users.Add(new UserId("test-id"), new User("test-id", "first name", "last name", "xxxx@xxxx"));
    }

    public void Add(User user)
    {
        _users.Add(user.Id, user);
    }

    public Task<User?> FindByIdAsync(UserId userId)
    {
        if (_users.ContainsKey(userId))
        {
            return Task.FromResult<User?>(_users[userId]);
        }
        else
        {
            return Task.FromResult<User?>(null);
        }
    }
}
