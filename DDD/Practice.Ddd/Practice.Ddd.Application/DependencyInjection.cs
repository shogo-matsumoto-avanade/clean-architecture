using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Practice.Ddd.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(Practice.Ddd.Application.DependencyInjection).Assembly;
        services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
