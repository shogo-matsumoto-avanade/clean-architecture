﻿namespace Practice.Ddd.Domain.Users
{
    public interface IUserRepository
    {
        public Task<User?> FindByIdAsync(UserId userId, CancellationToken cancellationToken = default);

        public void Add(User user);

        Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken = default);

        public void Remove(User user);
    }
}
