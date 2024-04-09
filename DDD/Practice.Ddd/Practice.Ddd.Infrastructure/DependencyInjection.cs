using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Services;
using Practice.Ddd.Infrastructure.Logs;
using Practice.Ddd.Infrastructure.Services;

namespace Practice.Ddd.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDomainLogger, DomainLogger>();
        services.AddScoped<IMessageBus, MessageBus>();
        services.AddScoped<IBus, Bus>();
        return services;
    }
}
