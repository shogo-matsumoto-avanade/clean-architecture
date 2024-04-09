using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Services;

public interface IDomainLogger
{
    void UserCreated(UserId userId, string userName, string email);
}
