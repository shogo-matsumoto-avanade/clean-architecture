namespace Practice.Ddd.Domain.Products;

public class Sku
{
    private const int _defaultLength = 15;

    public Sku(string value) => Value = value;

    public string Value { get; private set; }

    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value.Length != _defaultLength)
        {
            return null;
        }
        return new Sku(value);
    }
}