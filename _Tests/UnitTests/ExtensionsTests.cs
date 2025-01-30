using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.ExtensionsTestsDataSource;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = Args;

    [Theory, MemberData(nameof(AddTheoryData), MemberType = typeof(ExtensionsTestsDataSource))]
    public void ObjectArray_Add_args_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        Assert.Equal(expected, actual);
    }
}
