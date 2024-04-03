namespace Practice.Ddd.Domain.Customers;

public class CustomerId(Guid value)
{
    public Guid Value { get; private set; } = value;
}
