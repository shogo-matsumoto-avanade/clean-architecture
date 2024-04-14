using Practice.Ddd.Domain.Primitives;

namespace Practice.Ddd.Domain.Customers;

public class Customer : DomainEntity
{
    public CustomerId Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
}
