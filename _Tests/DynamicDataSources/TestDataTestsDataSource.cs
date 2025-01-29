namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataTestsDataSource
{
    private static readonly TestData<int> TestDataArgs1
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1);

    private static readonly TestData<int, object> TestDataArgs2
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2);

    private static readonly TestData<int, object, DateTime> TestDataArgs3
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3);

    private static readonly TestData<int, object, DateTime, string> TestDataArgs4
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4);

    private static readonly TestData<int, object, DateTime, string, double> TestDataArgs5
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5);

    private static readonly TestData<int, object, DateTime, string, double, bool> TestDataArgs6
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6);

    private static readonly TestData<int, object, DateTime, string, double, bool, char> TestDataArgs7
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7);

    private static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass> TestDataArgs8
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8);

    private static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataArgs9
        = new(Params.ActualDefinition, Params.ExpectedString, Params.Arg1, Params.Arg2, Params.Arg3, Params.Arg4, Params.Arg5, Params.Arg6, Params.Arg7, Params.Arg8, Params.Arg9);

    private static string TestCase
    => GetTestCase(Params.ActualDefinition, Params.ExpectedString);

    private static string GetTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    private static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

    public static TheoryData<string, string>PropertyArgsList => new()
    {
        { null, null },
        { string.Empty, string.Empty },
        { Params.NotNullProperty, Params.NotNullProperty },
    };

    public static TheoryData<string, string, string, string> TestCaseArgsList => new()
    {
        #region null
        { null, null, null, GetTestCase(Params.Definition, Params.Result) },
        { Params.ActualDefinition, null, null , GetTestCase(Params.ActualDefinition, Params.Result) },
        { Params.ActualDefinition, Params.ActualExitMode, null, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        { Params.ActualDefinition, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { null, null, Params.ActualResult, GetTestCase(Params.Definition, Params.ActualResult) },
        { null, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.Definition, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { Params.ActualDefinition, null, Params.ActualResult, GetTestCase(Params.ActualDefinition, Params.ActualResult) },
        { null, Params.ActualExitMode, null, GetTestCase(Params.Definition, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        #endregion

        #region string.Empty
        { string.Empty, Params.ActualExitMode, Params.ActualResult, GetTestCase(Params.Definition, GetExitModeResult(Params.ActualExitMode, Params.ActualResult)) },
        { Params.ActualDefinition, string.Empty, Params.ActualResult, GetTestCase(Params.ActualDefinition, Params.ActualResult) },
        { Params.ActualDefinition, Params.ActualExitMode, string.Empty, GetTestCase(Params.ActualDefinition, GetExitModeResult(Params.ActualExitMode, Params.Result)) },
        #endregion
    };

    public static TheoryData<ArgsCode, object[]> AbstractToArgsArgsList => new()
    {
        { ArgsCode.Instance, [Params.TestData] },
        { ArgsCode.Properties, [Params.TestData.TestCase] },
    };

    public static TheoryData<ArgsCode, ITestData<string>, object[]> ToArgsArgsList => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataArgs1, [TestCase, .. Params.Args1] },
        { ArgsCode.Properties, TestDataArgs2, [TestCase, .. Params.Args2] },
        { ArgsCode.Properties, TestDataArgs3, [TestCase, .. Params.Args3] },
        { ArgsCode.Properties, TestDataArgs4, [TestCase, .. Params.Args4] },
        { ArgsCode.Properties, TestDataArgs5, [TestCase, .. Params.Args5] },
        { ArgsCode.Properties, TestDataArgs6, [TestCase, .. Params.Args6] },
        { ArgsCode.Properties, TestDataArgs7, [TestCase, .. Params.Args7] },
        { ArgsCode.Properties, TestDataArgs8, [TestCase, .. Params.Args8] },
        { ArgsCode.Properties, TestDataArgs9, [TestCase, .. Params.Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataArgs1, [TestDataArgs1] },
        { ArgsCode.Instance, TestDataArgs2, [TestDataArgs2] },
        { ArgsCode.Instance, TestDataArgs3, [TestDataArgs3] },
        { ArgsCode.Instance, TestDataArgs4, [TestDataArgs4] },
        { ArgsCode.Instance, TestDataArgs5, [TestDataArgs5] },
        { ArgsCode.Instance, TestDataArgs6, [TestDataArgs6] },
        { ArgsCode.Instance, TestDataArgs7, [TestDataArgs7] },
        { ArgsCode.Instance, TestDataArgs8, [TestDataArgs8] },
        { ArgsCode.Instance, TestDataArgs9, [TestDataArgs9] },
        #endregion
    };
}
