
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
            throw new ArgumentException($"The value has been exceeded the max length", nameof(Email));
        if (!Regex.IsMatch(value, "^[A-Za-z0-9]+[A-Za-z0-9_.-]*@[A-Za-z0-9_.-]+\\.[A-Za-z0-9]+$"))
            throw new ArgumentException($"The format of value is invalid", nameof(Email));

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
