using Practice.Ddd.Domain.Users;
using Practice.Ddd.Persistence;

namespace Practice.Ddd.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(User user)
    {
        _dbContext.Add(user);
    }

    public User? Find(UserId userId)
    {
        var user = _dbContext.Find(typeof(User), userId);
        return user is null ? null : (User)user;
    }
}
