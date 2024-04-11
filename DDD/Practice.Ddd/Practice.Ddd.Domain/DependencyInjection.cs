using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
