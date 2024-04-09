namespace Practice.Ddd.Domain.Users;

public class UserId : ValueObject
{
    public string Value { get; private set; }
    public UserId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(UserId));
        }
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    protected override string ValueObjectToString()
    {
        return Value;
    }
}
