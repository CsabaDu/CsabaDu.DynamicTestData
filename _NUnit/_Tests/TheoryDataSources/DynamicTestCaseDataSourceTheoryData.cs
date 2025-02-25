using static CsabaDu.DynamicTestData.TestHelpers.TestParameters.TestCaseDataArgs;

namespace CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;

public class DynamicTestCaseDataSourceTheoryData
{
    #region TestDataToTestCaseData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs1)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs1)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs1)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Arg1) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Arg1) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Arg1) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs2)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs2)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs2)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args2) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args2) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args2) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs3) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs3) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs3) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args3) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args3) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args3) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs4) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs4) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs4) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args4) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args4) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args4) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs5) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs5) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs5) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args5) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args5) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args5) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs6) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs6) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs6) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args6) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args6) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args6) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs7) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs7) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs7) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args7) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args7) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args7) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs8) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs8) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs8) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args8) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args8) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args8) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataToTestCaseData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataTestCase, TestDataArgs9) },
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataTestCase, TestDataArgs9) },
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataTestCase, TestDataArgs9) },
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataTestCase, Args9) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataTestCase, Args9) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataTestCase, Args9) },
    };
    #endregion

    #region TestDataReturnsToTestCaseData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs1)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs1)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs1)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, DummyEnumTestValue, Arg1) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, DummyEnumTestValue, Arg1) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, DummyEnumTestValue, Arg1) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs2)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs2)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs2)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args2]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args2]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args2]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs3)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs3)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs3)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args3]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args3]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args3]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs4)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs4)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs4)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args4]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args4]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args4]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs5)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs5)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs5)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args5]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args5]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args5]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs6)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs6)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs6)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args6]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args6]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args6]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs7)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs7)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs7)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args7]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args7]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args7]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs8)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs8)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs8)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args8]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args8]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args8]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataReturnsToTestCaseData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs9)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs9)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, TestDataReturnsArgs9)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args9]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args9]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataReturnsTestCase, [DummyEnumTestValue, .. Args9]) },
    };
    #endregion

    #region TestDataThrowsToTestCaseData data sources
    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs1)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs1)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs1)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, DummyExceptionInstance, Arg1) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, DummyExceptionInstance, Arg1) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, DummyExceptionInstance, Arg1) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs2)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs2)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs2)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args2]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args2]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args2]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs3)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs3)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs3)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args3]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args3]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args3]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs4)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs4)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs4)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args4]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args4]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args4]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs5)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs5)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs5)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args5]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args5]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args5]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs6)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs6)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs6)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args6]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args6]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args6]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs7)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs7)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs7)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args7]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args7]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args7]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs8)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs8)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs8)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args8]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args8]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args8]) },
    };

    public static TheoryData<ArgsCode, string, bool, TestCaseData> TestDataThrowsToTestCaseData9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs9)},
        { ArgsCode.Instance, null, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs9)},
        { ArgsCode.Instance, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, TestDataThrowsArgs9)},
        { ArgsCode.Properties, TestMethodName, true, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args9]) },
        { ArgsCode.Properties, null, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args9]) },
        { ArgsCode.Properties, string.Empty, false, GetTestCaseData(TestDataThrowsTestCase, [DummyExceptionInstance, .. Args9]) },
    };
    #endregion
}
