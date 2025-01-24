namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _args = [null, "test"];

    private ArgsCode _argsCode;
    private int?[] _parameters;
    private object[] _expected;

    private static readonly ExtensionsTests DataSource = new();

    public static IEnumerable<object[]> AddArgsList => DataSource.Add_ArgsToList();

    private IEnumerable<object[]> Add_ArgsToList()
    {
        #region Argscode.Instance
        _argsCode = ArgsCode.Instance;
        _parameters = [2, 3];
        _expected = _args;
        yield return testDataToArgs();
        #endregion

        #region Argscode.Properties
        _argsCode = ArgsCode.Properties;
        _parameters = [2, 3];
        _expected = [.. _args, 2, 3];
        yield return testDataToArgs();

        _argsCode = ArgsCode.Properties;
        _parameters = [null, 3];
        _expected = [.. _args, null, 3];
        yield return testDataToArgs();

        _argsCode = ArgsCode.Properties;
        _parameters = [];
        _expected = _args;
        yield return testDataToArgs();
        #endregion

        object[] testDataToArgs() => [_argsCode, _parameters, _expected];
    }

    [Theory, MemberData(nameof(AddArgsList))]
    public void ObjectArray_Add_arg_ArgsCode_arg_paramsObjectArray_returnsExpected(ArgsCode argsCode, int?[] parameters, object[] expected)
    {
        // Arrange
        // Act
        var actual = _args.Add(argsCode, parameters);

        // Assert
        Assert.Equal(expected, actual);
    }
}
