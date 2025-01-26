namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private static readonly ExtensionsTestsDataSources DataSource = new();
    private readonly object[] _sut = DataSource.Sut;

    [Theory, MemberData(nameof(ExtensionsTestsDataSources.AddArgsList), MemberType = typeof(ExtensionsTestsDataSources))]
    public void ObjectArray_Add_arg_ArgsCode_arg_paramsObjectArray_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        Assert.Equal(expected, actual);
    }

}
