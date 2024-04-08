﻿namespace Practice.Ddd.Domain.Users
{
    public interface IUserRepository
    {
        public Task<User?> FindByIdAsync(UserId userId);

        public void Add(User user);
    }
}
