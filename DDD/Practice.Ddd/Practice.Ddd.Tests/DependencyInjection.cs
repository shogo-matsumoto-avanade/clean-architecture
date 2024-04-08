using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Persistence;
using Practice.Ddd.Persistence.Repositories;

namespace Practice.Ddd.Tests;

public static class DependencyInjection
{
    public static IServiceCollection AddTestSettings(this IServiceCollection services)
    {
        services.AddLogging();
        return services;
    }

    public static IServiceCollection AddTestInfrastructure(this IServiceCollection services)
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
