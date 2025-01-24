namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

internal class ExtensionsDynamicDataSources
{
    private readonly object[] _args = [null, "test"];

    private string _testCaseName;
    private ArgsCode _argsCode;
    private int?[] _parameters;
    private object[] _expected;

    internal IEnumerable<object[]> Add_ArgsToList()
    {
        #region Argscode.Instance
        _testCaseName = "Argscode.Instance => returns object array with the same elements";
        _argsCode = ArgsCode.Instance;
        _parameters = [2, 3];
        _expected = _args;
        yield return testDataToArgs();
        #endregion

        #region Argscode.Properties
        _testCaseName = "Argscode.Properties => returns object array with the same elements and the new notnull ones";
        _argsCode = ArgsCode.Properties;
        _parameters = [2, 3];
        _expected = [.. _args, 2, 3];
        yield return testDataToArgs();

        _testCaseName = "Argscode.Properties => returns object array with the same elements and the new null and notnull ones";
        _argsCode = ArgsCode.Properties;
        _parameters = [null, 3];
        _expected = [.. _args, null, 3];
        yield return testDataToArgs();
        #endregion

        object[] testDataToArgs()
        => new TestDataRecord(_testCaseName, _argsCode, _parameters, _expected).ToArgs();
    }

}
