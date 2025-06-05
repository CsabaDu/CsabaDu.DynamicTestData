// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClass
{
    public const string GreaterThanCurrentDateTimeMessage
        = "The DateTime parameter cannot be greater than the current date and time.";

    public bool IsOlder(DateTime thisDate, DateTime otherDate)
    {
        if (thisDate <= DateTime.Now && otherDate <= DateTime.Now)
        {
            return thisDate > otherDate;
        }

        throw new ArgumentOutOfRangeException(getParamName(), GreaterThanCurrentDateTimeMessage);

        #region Local methods
        string getParamName()
        => thisDate > DateTime.Now ? nameof(thisDate) : nameof(otherDate);
        #endregion
    }
}

public class BirthDay : IComparable<BirthDay>
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    public BirthDay(string name, DateOnly dateOfBirth)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            name,
            nameof(name));

        Name = name;
        DateOfBirth = Validated(
            dateOfBirth,
            nameof(dateOfBirth));
    }

    public const string GreaterThanTheCurrentDateMessage
        = "Date of birth cannot be " +
        "greater than the current date.";

    public string Name { get; init; }

    public DateOnly DateOfBirth { get; init; }

    public int CompareTo(BirthDay? other)
    {
        string paramName = nameof(other);

        ArgumentNullException.ThrowIfNull(
            other,
            paramName);

        var validated = Validated(
            other.DateOfBirth,
            paramName);

        return DateOfBirth.CompareTo(validated);
    }

    private static DateOnly Validated(
        DateOnly dateOfBirth,
        string paramName)
    {
        if (dateOfBirth >= Today)
        {
            return dateOfBirth;
        }
        
        throw new ArgumentOutOfRangeException(
            paramName,
            GreaterThanTheCurrentDateMessage);
    }
}

