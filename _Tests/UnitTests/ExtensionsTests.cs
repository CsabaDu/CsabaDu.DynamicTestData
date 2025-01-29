namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = ExtensionsTestsDataSource.Args;

    [Theory, MemberData(nameof(ExtensionsTestsDataSource.AddArgsList), MemberType = typeof(ExtensionsTestsDataSource))]
    public void ObjectArray_Add_args_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
    }
}
