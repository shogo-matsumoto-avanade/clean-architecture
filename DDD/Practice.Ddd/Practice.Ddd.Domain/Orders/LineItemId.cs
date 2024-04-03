namespace Practice.Ddd.Domain.Orders;

public class LineItemId(Guid value)
{
    public Guid Value { get; private set; } = value;
}