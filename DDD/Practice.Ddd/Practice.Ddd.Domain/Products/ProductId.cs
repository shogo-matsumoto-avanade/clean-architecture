namespace Practice.Ddd.Domain.Products;

public class ProductId(Guid value)
{
    public Guid Value { get; private set; } = value;
}