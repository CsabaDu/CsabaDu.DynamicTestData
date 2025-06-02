// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.xUnit.DynamicDataSources;
using CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

class TestDataToTheoryDataSource(ArgsCode argsCode) : DynamicTheoryDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;


    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public ITheoryTestData? IsOlderReturns(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";      
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptional' method.
        addOptional();

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        // 3. Call 'addOptional' method.
        addOptional();

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        // 3. Call 'addOptional' method.
        addOptional();

        return TheoryTestData;

        #region Local methods
        // 2. Add 'addOptional' local method to the enclosing method
        // and call 'AddOptional' method with the 'addtestDataToTheoryeData' and argsCode parameters.
        void addOptional()
        => AddOptional(add, argsCode);

        void add()
        => AddReturns(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    public ITheoryTestData? IsOlderThrows()
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        add();

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        add();

        return TheoryTestData;

        #region Local methods
        void add()
        => AddThrows(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
