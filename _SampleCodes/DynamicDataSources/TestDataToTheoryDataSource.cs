// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.xUnit.DynamicDataSources;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

class TestDataToTheoryDataSource(ArgsCode argsCode) : DynamicTheoryDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public TheoryData? IsOlderReturnsToTheoryData(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptionalToTheoryData' method.
        addOptionalToTheoryData();

        return TheoryData;

        #region Local methods
        // 2. Add 'addOptionalToTheoryData' local method to the enclosing method
        // and call 'AddOptionalToTheoryData' method with the 'addtestDataToTheoryeData' and argsCode parameters.
        void addOptionalToTheoryData()
        => AddOptionalToTheoryData(addTestDataToTheoryData, argsCode);

        void addTestDataToTheoryData()
        => AddTestDataReturnsToTheoryData(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public TheoryData? IsOlderThrowsToTheoryData()
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        addTestDataToTheoryData();

        return TheoryData;

        #region Local methods
        void addTestDataToTheoryData()
        => AddTestDataThrowsToTheoryData(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
