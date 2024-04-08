using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Orders;
using Practice.Ddd.Domain.Products;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Data;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// The property name of DbSet objects must be match the Table name
    /// </summary>
    public DbSet<User> User { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<LineItem> LineItem { get; set; }
    public DbSet<Product> Product { get; set; }
}
