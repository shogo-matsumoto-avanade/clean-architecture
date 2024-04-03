using Practice.Ddd.Domain.Customers;

namespace Practice.Ddd.Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();
    private Order() { }

    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

    public Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
        };
        return order;
    }

}
