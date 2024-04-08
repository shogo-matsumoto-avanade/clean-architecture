using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
    }

    public async Task<User?> FindByIdAsync(UserId userId)
    {
        return await _dbContext.FindAsync<User>(userId);
    }
}
