using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;
    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.User.Add(user);
    }

    public async Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await _context.User.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> FindByIdAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return await _context.User.FindAsync(userId, cancellationToken);
    }

    public void Remove(User user)
    {
        _context.User.Remove(user);
    }
}
