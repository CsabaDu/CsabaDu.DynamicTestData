namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataTestsDynamicDataSource
{
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
}
