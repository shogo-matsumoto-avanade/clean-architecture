﻿
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
            throw new ArgumentException($"Input parameter of has been exceeded the max length", nameof(Email));
        if (!Regex.IsMatch(value, "[\\w\\-\\._]+@[\\w\\-\\._]+\\.[A-Za-z]+"))
            throw new ArgumentException($"Invalid format of {nameof(Email)} value object", nameof(Email));

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
