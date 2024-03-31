﻿using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Infrastructure.Users;

public class InMemoryUserRepository : IUserRepository
{
    public void Create(string userName, string firstName, string lastName)
    {
        throw new NotImplementedException();
    }

    public User Find(UserId userId)
    {
        if (!userId.Equals(new UserId("test"))) return null;
        return new User("test", "test name");
    }
}
