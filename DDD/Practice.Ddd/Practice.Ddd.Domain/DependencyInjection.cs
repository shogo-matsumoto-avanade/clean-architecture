using Microsoft.Extensions.DependencyInjection;

namespace Practice.Ddd.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
