namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataTestsDataSource
{
    private static readonly TestData<int> TestDataArgs1
        = new(ActualDefinition, ExpectedString, Arg1);

    private static readonly TestData<int, object> TestDataArgs2
        = new(ActualDefinition, ExpectedString, Arg1, Arg2);

    private static readonly TestData<int, object, DateTime> TestDataArgs3
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    private static readonly TestData<int, object, DateTime, string> TestDataArgs4
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    private static readonly TestData<int, object, DateTime, string, double> TestDataArgs5
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    private static readonly TestData<int, object, DateTime, string, double, bool> TestDataArgs6
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    private static readonly TestData<int, object, DateTime, string, double, bool, char> TestDataArgs7
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    private static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass> TestDataArgs8
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    private static readonly TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataArgs9
        = new(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    private static string TestCase
    => GetTestCase(ActualDefinition, ExpectedString);

    public static TheoryData<string, string>PropertyTheoryData => new()
    {
        { null, null },
        { string.Empty, string.Empty },
        { NotNullProperty, NotNullProperty },
    };

    public static TheoryData<string, string, string, string> TestCaseTheoryData => new()
    {
        #region null
        { null, null, null, GetTestCase(Definition, Result) },
        { ActualDefinition, null, null , GetTestCase(ActualDefinition, Result) },
        { ActualDefinition, ActualExitMode, null, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        { ActualDefinition, ActualExitMode, ActualResult, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { null, null, ActualResult, GetTestCase(Definition, ActualResult) },
        { null, ActualExitMode, ActualResult, GetTestCase(Definition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, null, ActualResult, GetTestCase(ActualDefinition, ActualResult) },
        { null, ActualExitMode, null, GetTestCase(Definition, GetExitModeResult(ActualExitMode, Result)) },
        #endregion

        #region string.Empty
        { string.Empty, ActualExitMode, ActualResult, GetTestCase(Definition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, string.Empty, ActualResult, GetTestCase(ActualDefinition, ActualResult) },
        { ActualDefinition, ActualExitMode, string.Empty, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        #endregion
    };

    public static TheoryData<ArgsCode, object[]> AbstractToArgsTheoryData => new()
    {
        { ArgsCode.Instance, [Params.TestDataChild] },
        { ArgsCode.Properties, [Params.TestDataChild.TestCase] },
    };

    public static TheoryData<ArgsCode, ITestData<string>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataArgs1, [TestCase, .. Args1] },
        { ArgsCode.Properties, TestDataArgs2, [TestCase, .. Args2] },
        { ArgsCode.Properties, TestDataArgs3, [TestCase, .. Args3] },
        { ArgsCode.Properties, TestDataArgs4, [TestCase, .. Args4] },
        { ArgsCode.Properties, TestDataArgs5, [TestCase, .. Args5] },
        { ArgsCode.Properties, TestDataArgs6, [TestCase, .. Args6] },
        { ArgsCode.Properties, TestDataArgs7, [TestCase, .. Args7] },
        { ArgsCode.Properties, TestDataArgs8, [TestCase, .. Args8] },
        { ArgsCode.Properties, TestDataArgs9, [TestCase, .. Args9] },
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
