
using System.Text.RegularExpressions;

namespace Practice.Ddd.Domain.Users;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        if (value is null) 
            throw new ArgumentNullException(nameof(Email));
        if (value.Length > 255) 
            throw new ArgumentException(nameof(Email));
        if (!Regex.IsMatch(value, "^[a-zA-Z0-9_+-]+(.[a-zA-Z0-9_+-]+)*@([a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9]*\\.)+[a-zA-Z]{2,}$"))
            throw new FormatException(nameof(Email));

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
