namespace Practice.Ddd.Domain.Orders;

public class OrderId(Guid value)
{
    public Guid Value { get; private set; } = value;
}
