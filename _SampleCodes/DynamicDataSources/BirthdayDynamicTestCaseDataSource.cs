//// SPDX-License-Identifier: MIT
//// Copyright (c) 2025. Csaba Dudas (CsabaDu)

//using CsabaDu.DynamicTestData.NUnit.DynamicDataSources;
//using NUnit.Framework;

//namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

//public class TestDataToTestCaseDataSource(ArgsCode argsCode, bool? withExpected) : DynamicTestCaseDataSource(argsCode, withExpected)
//{
//    private readonly DateTime DateTimeNow = DateTime.Now;

//    private DateTime _thisDate;
//    private DateTime _otherDate;

//    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
//    public IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList(string? testMethodName, ArgsCode? argsCode = null)
//    {
//        bool expected = true;
//        string definition = "thisDate is greater than otherDate";
//        _thisDate = DateTimeNow;
//        _otherDate = DateTimeNow.AddDays(-1);
//        // 3. Call 'optionalToTestCaseData' method.
//        yield return optionalToTestCaseData();

//        expected = false;
//        definition = "thisDate equals otherDate";
//        _otherDate = DateTimeNow;
//        // 3. Call 'optionalToTestCaseData' method.
//        yield return optionalToTestCaseData();

//        definition = "thisDate is less than otherDate";
//        _thisDate = DateTimeNow.AddDays(-1);
//        // 3. Call 'optionalToTestCaseData' method.
//        yield return optionalToTestCaseData();

//        #region Local methods
//        // 2. Add 'optionalToTestCaseData' local method to the enclosing method
//        // and call 'OptionalToTestCaseData' method with the testDataToTestCaseData and argsCode parameters.
//        TestCaseData optionalToTestCaseData()
//        => OptionalToTestCaseData(testDataToTestCaseData, argsCode);

//        TestCaseData testDataToTestCaseData()
//        => TestDataReturnsToTestCaseData(definition, expected, _thisDate, _otherDate, testMethodName);
//        #endregion
//    }

//    public IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList(string? testMethodName)
//    {
//        string paramName = "otherDate";
//        _thisDate = DateTimeNow;
//        _otherDate = DateTimeNow.AddDays(1);
//        yield return testDataToTestCaseData();

//        paramName = "thisDate";
//        _thisDate = DateTimeNow.AddDays(1);
//        yield return testDataToTestCaseData();

//        #region Local methods
//        TestCaseData testDataToTestCaseData()
//        => TestDataThrowsToTestCaseData(getDefinition(), getExpected(), _thisDate, _otherDate, testMethodName);

//        string getDefinition()
//        => $"{paramName} is greater than the current date";

//        ArgumentOutOfRangeException getExpected()
//        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
//        #endregion
//    }
//}
