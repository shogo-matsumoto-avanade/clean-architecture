using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Handlers;
using Practice.Ddd.Application.Pipelines;

namespace Practice.Ddd.Tests;

public static class DependencyInjection
{
    public static IServiceCollection AddTest(this IServiceCollection services)
    {
        services.AddLogging();
        return services;
    }
}
