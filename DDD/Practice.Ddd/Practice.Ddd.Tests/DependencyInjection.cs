using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Application.PipelineBehaviors;
using Practice.Ddd.Application.Services;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Infrastructure.Services;
using Practice.Ddd.Persistence;
using Practice.Ddd.Persistence.Repositories;

namespace Practice.Ddd.Tests;

public static class DependencyInjection
{
    public static IServiceCollection AddIntegrationTestInfrastructure(this IServiceCollection services)
    { 
        services.AddLogging();

        services.AddScoped<Mock<IBus>, Mock<IBus>>();
        services.AddScoped(sp => 
            sp.GetRequiredService<Mock<IBus>>().Object);
        
        services.AddScoped<IMessageBus, MessageBus>();

        services.AddScoped<Mock<IDomainLogger>, Mock<IDomainLogger>>();
        services.AddScoped(sp =>
            sp.GetRequiredService<Mock<IDomainLogger>>().Object);

        return services;
    }

    public static IServiceCollection AddUnitTestApplication(this IServiceCollection services)
    {
        var assembly = typeof(Ddd.Application.DependencyInjection).Assembly;
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assembly);

            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);
        return services;
    }

    public static IServiceCollection AddTestPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=tcp:sqlserver-study.database.windows.net,1433;Initial Catalog=sqldb-practice;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";"));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
