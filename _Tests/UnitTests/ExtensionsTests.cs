namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _args = [null, "test"];
    private static readonly ExtensionsDynamicDataSources DataSource = new();

    public static IEnumerable<object[]> AddArgsList => DataSource.Add_ArgsToList();

    [Theory, MemberData(nameof(AddArgsList))]
    public void ObjectArray_Add_arg_ArgsCode_arg_paramsObjectArray_returnsExpected(TestDataRecord data)
    {
        // Arrange
        var argsCode = (ArgsCode)data.TestParams[0];
        var parameters = (int?[])data.TestParams[1];
        var arg1 = parameters[0];
        var arg2 = parameters[1];
        var expected = (object[])data.TestParams[2];

        // Act
        var actual = _args.Add(argsCode, arg1, arg2);

        // Assert
        Assert.Equal(expected, actual);
    }
}
