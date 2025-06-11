// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class NativeTestDataSource(ArgsCode argsCode, bool? withExpected) : DynamicParams(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    public override bool? WithExpected { get; } = withExpected;

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderReturnsArgsToList(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return optionalToParams(); // 3. Call 'optionalToParams' method.

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        yield return optionalToParams(); // 3. Call 'optionalToParams' method.

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        yield return optionalToParams(); // 3. Call 'optionalToParams' method.

        #region Local methods
        // 2. Add 'optionalToParams' local method to the enclosing method
        // and call 'WithOptionalArgsCode' method with the testDataToParams and argsCode parameters.
        object?[] optionalToParams()
        => WithOptionalArgsCode(testDataToParams, argsCode);

        object?[] testDataToParams()
        => TestDataReturnsToParams(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderThrowsArgsToList(ArgsCode? argsCode = null)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return optionalToParams(); // 3. Call 'optionalToParams' method.

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return optionalToParams(); // 3. Call 'optionalToParams' method.

        #region Local methods
        // 2. Add 'optionalToParams' local method to the enclosing method
        // and call 'WithOptionalArgsCode' method with the testDataToParams and argsCode parameters.
        object?[] optionalToParams()
        => WithOptionalArgsCode(testDataToParams, argsCode);

        object?[] testDataToParams()
        => TestDataThrowsToParams(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
