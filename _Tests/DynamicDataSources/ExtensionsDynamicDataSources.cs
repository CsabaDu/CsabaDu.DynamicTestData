namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class ExtensionsDynamicDataSources()
{
    public readonly object[] Args = [null, 1];
    private string _testCase;

    public IEnumerable<object[]> Add_ArgsToList()
    {
        #region Argscode.Instance
        ArgsCode argsCode = ArgsCode.Instance;
        setTestCaseName(argsCode, "returns object array with same elements") ;
        string parameter = "test";
        object[] expected = Args;
        yield return testDataToArgs();
        #endregion

        #region Argscode.Properties
        setTestCaseName(argsCode, "returns the object array with the new notnull element");
        argsCode = ArgsCode.Properties;
        parameter = "test";
        expected = [.. Args, parameter];
        yield return testDataToArgs();

        setTestCaseName(argsCode, "returns the object array with the new null element");
        argsCode = ArgsCode.Properties;
        parameter = null;
        expected = [.. Args, parameter];
        yield return testDataToArgs();
        #endregion

        void setTestCaseName(ArgsCode argsCode, string result)
        => _testCase = $"Argscode.{argsCode} => {result}";

        object[] testDataToArgs()
        => new TestDataRecord(_testCase, argsCode, parameter, expected).ToArgs();
    }
}
