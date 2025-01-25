namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private static readonly ExtensionsDynamicDataSources DataSource = new();
    private readonly object[] _args = DataSource.Args;

    public static IEnumerable<object[]> AddArgsList => DataSource.Add_ArgsToList();

    [Theory, MemberData(nameof(AddArgsList))]
    public void ObjectArray_Add_arg_ArgsCode_arg_paramsObjectArray_returnsExpected(TestDataRecord data)
    {
        // Arrange
        var argsCode = (ArgsCode)data.Params[0];
        var parameter = (string)data.Params[1];
        var expected = (object[])data.Params[2];

        // Act
        var actual = _args.Add(argsCode, parameter);

        // Assert
        Assert.Equal(expected, actual);
    }
}
