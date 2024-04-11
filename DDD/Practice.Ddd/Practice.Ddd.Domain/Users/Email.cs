
using System.Text.RegularExpressions;

namespace Practice.Ddd.Domain.Users;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(Email));
        if (value.Length > MaxLength)
            throw new ArgumentException($"The value has been exceeded the max length", nameof(Email));
        if (!Regex.IsMatch(value, FormatPattern))
            throw new ArgumentException($"The format of value is invalid", nameof(Email));

        Value = value;
    }


    public static int MaxLength => 255;
    public static string FormatPattern => "^[A-Za-z0-9]+[A-Za-z0-9_.-]*@[A-Za-z0-9_.-]+\\.[A-Za-z0-9]+$";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
