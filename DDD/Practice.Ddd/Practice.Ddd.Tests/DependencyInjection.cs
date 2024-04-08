using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Persistence;
using Practice.Ddd.Tests.Mocks.Repositories;

namespace Practice.Ddd.Tests;

public static class DependencyInjection
{
    public static IServiceCollection AddTestSettings(this IServiceCollection services)
    {
        services.AddLogging();
        return services;
    }

    public static IServiceCollection AddTestInfrastructure(this IServiceCollection services) //, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer("Server=tcp:sqlserver-study.database.windows.net,1433;Initial Catalog=sqldb-practice;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";"));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork, ApplicationDbContext>();

        services.AddScoped<IUserRepository, InMemoryUserRepository>();

        return services;
    }
}
