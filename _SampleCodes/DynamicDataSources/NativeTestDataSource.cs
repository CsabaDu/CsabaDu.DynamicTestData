// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class NativeTestDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderReturnsArgsToList(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        #region Local methods
        // 2. Add 'optionalToArgs' local method to the enclosing method
        // and call 'OptionalToArgs' method with the testDataToArgs and argsCode parameters.
        object?[] optionalToArgs()
        => OptionalToArgs(testDataToArgs, argsCode);

        object?[] testDataToArgs()
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderThrowsArgsToList(ArgsCode? argsCode = null)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        #region Local methods
        // 2. Add 'optionalToArgs' local method to the enclosing method
        // and call 'OptionalToArgs' method with the testDataToArgs and argsCode parameters.
        object?[] optionalToArgs()
        => OptionalToArgs(testDataToArgs, argsCode);

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
