using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.PipelineBehaviors;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assembly);

            // Priority of pipeline behaviors can be changed by the order in which pipeline behaviors are registered
            config.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
