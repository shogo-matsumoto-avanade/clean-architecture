using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Infrastructure.Users;

namespace Practice.Ddd.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddInMemoryInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, InMemoryUserRepository>();
        return services;
    }
}
