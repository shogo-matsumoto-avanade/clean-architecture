using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Orders;
using Practice.Ddd.Domain.Products;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> User { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<LineItem> LineItem { get; set; }
    public DbSet<Product> Product { get; set; }
}
