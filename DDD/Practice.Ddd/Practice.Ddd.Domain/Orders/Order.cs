using Practice.Ddd.Domain.Customers;
using Practice.Ddd.Domain.Primitives;

namespace Practice.Ddd.Domain.Orders;

public class Order : DomainEntity
{
    private readonly HashSet<LineItem> _lineItems = [];
    private Order() { }

    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<LineItem> LineItems => [.. _lineItems];

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
        };
        return order;
    }

}
