using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataTestsDynamicDataSource
{
    private static string GetTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    private static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

    private static string GetTestCase()
    => GetTestCase(Params.Definiton, Params.ExpectedString);

    public static TheoryData<string, string>PropertyArgsList => new()
    {
        { null, null },
        { string.Empty, string.Empty },
        { Params.NotNullProperty, Params.NotNullProperty },
    };

    public static TheoryData<string, string, string, string> TestCaseArgsList => new()
    {
        #region null
        { null, null, null, GetTestCase(Params.Definiton, Params.Result) },
        { Params.ActualDefinition, null, null , GetTestCase(Params.ActualDefinition, Params.Result) },
        { Params.ActualDefinition, Params.ActualExitMode, null, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        { Params.ActualDefinition, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { null, null, Params.ActualResult, GetTestCase(Params.Definiton, Params.ActualResult) },
        { null, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.Definiton, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { Params.ActualDefinition, null, Params.ActualResult, GetTestCase(Params.ActualDefinition, Params.ActualResult) },
        { null, Params.ActualExitMode, null, GetTestCase(Params.Definiton, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        #endregion

        #region string.Empty
        { string.Empty, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.Definiton, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { Params.ActualDefinition, string.Empty, Params.ActualResult, GetTestCase(Params.ActualDefinition, Params.ActualResult) },
        { Params.ActualDefinition, Params.ActualExitMode, string.Empty, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        #endregion
    };

    public static TheoryData<ArgsCode, object[]> ToArgsArgsList => new()
    {
        { ArgsCode.Instance, [Params.TestData] },
        { ArgsCode.Properties, [Params.TestData.TestCase] },
    };

    private static readonly TestData<int> TestData1param = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1);
    private static readonly TestData<int, object> TestData2params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2);
    private static readonly TestData<int, object, DateTime> TestData3params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3);
    private static readonly TestData<int, object, DateTime, string> TestData4params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4);
    private static readonly TestData<int, object, DateTime, string, double> TestData5params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5);
    private static readonly TestData<int, object, DateTime, string, double, bool> TestData6params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6);
    private static readonly TestData<int, object, DateTime, string, double, bool, char> TestData7params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7);
    private static readonly TestData<int, object, DateTime, string, double, bool, char, float> TestData8params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8);
    private static readonly TestData<int, object, DateTime, string, double, bool, char, float, object[]> TestData9params = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8, Params.Arg9);

    public static TheoryData<ITestData<string>, object[]> ToArgsArgsCodeInstanceArgsList => new()
    {
        { TestData1param, [TestData1param] },
        { TestData2params, [TestData2params] },
        { TestData3params, [TestData3params] },
        { TestData4params, [TestData4params] },
        { TestData5params, [TestData5params] },
        { TestData6params, [TestData6params] },
        { TestData7params, [TestData7params] },
        { TestData8params, [TestData8params] },
        { TestData9params, [TestData9params] },
    };

    //public static TheoryData<int, object,DateTime, string, double, bool, char, float, object[], object[]> ToArgsArgsCodeInstanceArgsList => new()
    //{
    //    { ArgsCode.Instance, Params.Arg1, [new TestData<int>(Params.ActualDefinition, Params.ExpectedString, Params.Arg1)] },
    //    { ArgsCode.Properties, Params.Arg1, [GetTestCase(Params.ActualDefinition, Params.ExpectedString), Params.Arg1] },
    //};
}
