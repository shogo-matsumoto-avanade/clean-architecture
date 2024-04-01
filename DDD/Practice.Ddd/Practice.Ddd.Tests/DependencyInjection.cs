using Microsoft.Extensions.DependencyInjection;

namespace Practice.Ddd.Tests;

public static class DependencyInjection
{
    public static IServiceCollection AddTestSettings(this IServiceCollection services)
    {
        services.AddLogging();
        return services;
    }
}
