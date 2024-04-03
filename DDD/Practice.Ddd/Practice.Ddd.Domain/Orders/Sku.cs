namespace Practice.Ddd.Domain.Orders;

public class Sku
{
    private const int DefaultLength = 15;

    public Sku(string value) => Value = value;

    public string Value { get; private set; }

    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value.Length != DefaultLength)
        {
            return null;
        }
        return new Sku(value);
    }
}