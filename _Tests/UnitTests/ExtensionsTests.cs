namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = ExtensionsTestsDataSources.Args;

    [Theory, MemberData(nameof(ExtensionsTestsDataSources.AddArgsList), MemberType = typeof(ExtensionsTestsDataSources))]
    public void ObjectArray_Add_args_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
    }
}
