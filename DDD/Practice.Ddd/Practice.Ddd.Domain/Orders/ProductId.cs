namespace Practice.Ddd.Domain.Orders;

public class ProductId(Guid value)
{
    public Guid Value { get; private set; } = value;
}