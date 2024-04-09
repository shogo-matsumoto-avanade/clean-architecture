namespace Practice.Ddd.Domain.Users
{
    public interface IUserRepository
    {
        public Task<User?> FindByIdAsync(UserId userId);

        public void Add(User user);

        Task<User?> FindByEmailAsync(Email email);

        public void Remove(User user);
    }
}
