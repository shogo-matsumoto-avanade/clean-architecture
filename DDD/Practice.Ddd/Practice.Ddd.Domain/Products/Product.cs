using Practice.Ddd.Domain.Primitives;

namespace Practice.Ddd.Domain.Products;

public class Product : DomainEntity
{
    public ProductId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; }
    public Sku Sku { get; private set; }
}