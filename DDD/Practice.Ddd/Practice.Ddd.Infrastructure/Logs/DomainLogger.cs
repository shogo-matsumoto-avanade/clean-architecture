using Microsoft.Extensions.Logging;
using Practice.Ddd.Application.Services;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Infrastructure.Logs;

public class DomainLogger : IDomainLogger
{
    private readonly ILogger<DomainLogger> _logger;

    public DomainLogger(ILogger<DomainLogger> logger)
    {
        _logger = logger;
    }

    public void UserCreated(UserId userId, string userName, string email)
    {
        _logger.LogInformation("An user has been created. Id: {userId}, Name: {userName}, Email: {email}", userId.Value, userName, email);
    }

}
