using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.ExtensionsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = ExtensionsArgs0;

    #region Extensions tests
    [Theory, MemberData(nameof(AddTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void ObjectArray_Add_args_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
}
