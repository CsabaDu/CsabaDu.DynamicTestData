namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataTestsDynamicDataSource
{
    private static readonly string ActualDefinition = "Test Definition";
    private static readonly string ActualResult = "Test Result";
    private static readonly string ActualExitMode = "Test Exit Mode";
    private static readonly string Definiton = nameof(TestData.Definition);
    private static readonly string Result = nameof(TestData.Result);
    private static readonly string NotNullProperty = "Test Property";

    public static readonly TestDataChild TestData = new(ActualDefinition, ActualResult, ActualExitMode);

    private static string GetTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    private static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

    public static TheoryData<string, string>PropertyArgsList => new()
    {
        { null, null },
        { string.Empty, string.Empty },
        { NotNullProperty, NotNullProperty },
    };

    public static TheoryData<string, string, string, string> TestCaseArgsList => new()
    {
        #region null
        { null, null, null, GetTestCase(Definiton, Result) },
        { ActualDefinition, null, null , GetTestCase(ActualDefinition, Result) },
        { ActualDefinition, ActualExitMode, null, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        { ActualDefinition, ActualExitMode, ActualResult, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, ActualResult)) },
        { null, null, ActualResult, GetTestCase(Definiton, ActualResult) },
        { null, ActualExitMode, ActualResult, GetTestCase(Definiton, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, null, ActualResult, GetTestCase(ActualDefinition, ActualResult) },
        { null, ActualExitMode, null, GetTestCase(Definiton, GetExitModeResult(ActualExitMode, Result)) },
        #endregion

        #region string.Empty
        { string.Empty, ActualExitMode, ActualResult, GetTestCase(Definiton, GetExitModeResult(ActualExitMode, ActualResult)) },
        { ActualDefinition, string.Empty, ActualResult, GetTestCase(ActualDefinition, ActualResult) },
        { ActualDefinition, ActualExitMode, string.Empty, GetTestCase(ActualDefinition, GetExitModeResult(ActualExitMode, Result)) },
        #endregion
    };

    public static TheoryData<ArgsCode, object[]> ToArgsArgsList => new()
    {
        { ArgsCode.Instance, [TestData] },
        { ArgsCode.Properties, [TestData.TestCase] },
    };
}
