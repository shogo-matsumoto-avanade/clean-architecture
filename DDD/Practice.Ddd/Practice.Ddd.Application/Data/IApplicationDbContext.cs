using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Orders;
using Practice.Ddd.Domain.Products;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Application.Data;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //public DbSet<User> Users { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<LineItem> LineItems { get; set; }
    //public DbSet<Product> Products { get; set; }
}
