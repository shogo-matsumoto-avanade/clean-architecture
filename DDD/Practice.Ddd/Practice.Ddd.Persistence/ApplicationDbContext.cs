using MediatR;
using Microsoft.EntityFrameworkCore;
using Practice.Ddd.Application.Data;
using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Orders;
using Practice.Ddd.Domain.Primitives;
using Practice.Ddd.Domain.Products;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker will be updated and cleared after SaveChanges, so ToList() needs to be called.
        var domentEvents = ChangeTracker.Entries<DomainEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count != 0)
            .SelectMany(e => e.DomainEvents).ToList();

        var result = await base.SaveChangesAsync(cancellationToken);
        
        foreach (var domainEvent in domentEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
        return result;
    }
}
