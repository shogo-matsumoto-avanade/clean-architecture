using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Pipelines;

namespace Practice.Ddd.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        // Priority of pipeline behaviors can be changed by the order in which pipeline behaviors are registered
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }
}
