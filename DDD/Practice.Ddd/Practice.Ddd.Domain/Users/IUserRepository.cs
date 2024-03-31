namespace Practice.Ddd.Domain.Users
{
    public interface IUserRepository
    {
        public User Find(UserId userId);

        public void Create(string userName, string firstName, string lastName);
    }
}
