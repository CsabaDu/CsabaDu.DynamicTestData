// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.SampleCodes;

public class BirthDay : IComparable<BirthDay>
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);

    public string Name { get; init; }

    public DateOnly DateOfBirth { get; init; }

    public const string GreaterThanTheCurrentDateMessage
        = "Date of birth cannot be " +
        "greater than the current date.";

    // name is null => throws ArguemntNullException
    // name is empty => throws ArgumentException
    // name is white space => throws ArgumentException
    // dateOfBirth is less than the current day => throws ArgumentOutOfRangeException

    // dateOfBirth is equal with the current day => creates BirthDay instance
    // dateOfBirth is greater than the current day => creates BirthDay instance
    public BirthDay(string name, DateOnly dateOfBirth)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            name,
            nameof(name));

        if (dateOfBirth > Today)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dateOfBirth),
                GreaterThanTheCurrentDateMessage);
        }

        Name = name;
        DateOfBirth = dateOfBirth;
    }

    // other is null => returns -1
    // this.DateOfBirth is less than other.DateOfBirth => returns -1
    // this.DateOfBirth is equal with other.DateOfBirth => return 0
    // this.DateOfBirth is greater than other.DateOfBirth => returns 1
    public int CompareTo(BirthDay? other)
    => DateOfBirth.CompareTo(other?.DateOfBirth ?? Today);
}

