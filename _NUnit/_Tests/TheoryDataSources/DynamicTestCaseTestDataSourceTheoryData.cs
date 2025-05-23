// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;

namespace CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;

public class DynamicTestCaseTestDataSourceTheoryData
{
    #region OtionalToTestCaseTestDataTheoryData
    private static TestCaseTestData GetInstanceTestCaseTestData()
    => TestDataToTestCaseTestData(ArgsCode.Instance, TestMethodName);

    private static TestCaseTestData GetPropertiesTestCaseTestData()
    => TestDataToTestCaseTestData(ArgsCode.Properties, TestMethodName);

    private static TestCaseTestData TestDataToTestCaseTestData(ArgsCode argsCode, string testMethodName)
    => new DynamicTestCaseTestDataSourceChild(argsCode)
        .TestDataToTestCaseTestData(
            ActualDefinition,
            ExpectedString,
            Arg1,
            testMethodName);

    public static TheoryData<ArgsCode, ArgsCode?, Func<TestCaseTestData>, TestCaseTestData> OptionalToTestCaseTestDataTheoryData => new()
    {
        { ArgsCode.Instance, null, GetInstanceTestCaseTestData, GetInstanceTestCaseTestData() },
        { ArgsCode.Instance, ArgsCode.Instance, GetInstanceTestCaseTestData, GetInstanceTestCaseTestData() },
        { ArgsCode.Instance, ArgsCode.Properties, GetPropertiesTestCaseTestData, GetPropertiesTestCaseTestData()},
        { ArgsCode.Properties, null, GetPropertiesTestCaseTestData, GetPropertiesTestCaseTestData()},
        { ArgsCode.Properties, ArgsCode.Instance, GetInstanceTestCaseTestData, GetInstanceTestCaseTestData() },
        { ArgsCode.Properties, ArgsCode.Properties, GetPropertiesTestCaseTestData , GetPropertiesTestCaseTestData()},
    };
    #endregion

    #region TestDataToTestCaseTestData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs1, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs1, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs1, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs1, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs2, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs2, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs2, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs2, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs3, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs3, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs3, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs3, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs4, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs4, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs4, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs4, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs5, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs5, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs5, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs5, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs6, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs6, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs6, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs6, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs7, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs7, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs7, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs7, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs8, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs8, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs8, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs8, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataToTestCaseTestData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataArgs9, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataArgs9, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataArgs9, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataArgs9, ArgsCode.Properties, null) },
    };
    #endregion

    #region TestDataReturnsToTestCaseTestData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs1, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs1, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs1, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs1, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs2, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs2, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs2, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs2, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs3, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs3, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs3, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs3, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs4, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs4, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs4, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs4, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs5, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs5, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs5, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs5, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs6, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs6, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs6, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs6, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs7, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs7, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs7, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs7, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs8, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs8, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs8, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs8, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataReturnsToTestCaseTestData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataReturnsArgs9, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataReturnsArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataReturnsArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataReturnsArgs9, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataReturnsArgs9, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataReturnsArgs9, ArgsCode.Properties, null) },
    };
    #endregion

    #region TestDataThrowsToTestCaseTestData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs1, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs1, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs1, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs1, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs1, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs2, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs2, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs2, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs2, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs2, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs3, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs3, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs3, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs3, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs3, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs4, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs4, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs4, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs4, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs4, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs5, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs5, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs5, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs5, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs5, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs6, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs6, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs6, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs6, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs6, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs7, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs7, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs7, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs7, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs7, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs8, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs8, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs8, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs8, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs8, ArgsCode.Properties, null) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseTestData> TestDataThrowsToTestCaseTestData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, new(TestDataThrowsArgs9, ArgsCode.Instance, TestMethodName) },
        { ArgsCode.Instance, null, false, new(TestDataThrowsArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Instance, string.Empty, false, new(TestDataThrowsArgs9, ArgsCode.Instance, null) },
        { ArgsCode.Properties, TestMethodName, true, new(TestDataThrowsArgs9, ArgsCode.Properties, TestMethodName) },
        { ArgsCode.Properties, null, false, new(TestDataThrowsArgs9, ArgsCode.Properties, null) },
        { ArgsCode.Properties, string.Empty, false, new(TestDataThrowsArgs9, ArgsCode.Properties, null) },
    };
    #endregion
}
