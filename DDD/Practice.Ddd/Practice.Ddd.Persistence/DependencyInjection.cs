using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Users;
using Practice.Ddd.Persistence.Repositories;

namespace Practice.Ddd.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IApplicationDbContext>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork, ApplicationDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
