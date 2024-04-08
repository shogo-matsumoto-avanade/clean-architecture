using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Orders;
using Practice.Ddd.Domain.Products;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    //public DbSet<User> Users { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<LineItem> LineItems { get; set; }
    //public DbSet<Product> Products { get; set; }
}
