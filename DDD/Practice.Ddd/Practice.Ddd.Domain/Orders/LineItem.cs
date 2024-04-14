﻿using Practice.Ddd.Domain.Primitives;
using Practice.Ddd.Domain.Products;

namespace Practice.Ddd.Domain.Orders;

public class LineItem : DomainEntity
{
    private LineItem() { }

    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    public LineItemId Id { get; private set; }
    
    public OrderId OrderId { get; private set; }
    
    public ProductId ProductId { get; private set; }

    public Money Price { get; private set; }
}
