using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.ExtensionsTheoryData;
using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.SharedTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = ExtensionsArgs0;

    #region object?[] extensions tests
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

    #region ArgsCode extensions tests
    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Defined_validArg_ArgsCode_returnsExpected(ArgsCode expected)
    {
        // Arrange

        // Act
        var actual = expected.Defined(null);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Defined_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange
        int invalidIndex = Enum.GetNames<ArgsCode>().Length;
        ArgsCode argsCode = (ArgsCode)invalidIndex;
        string paramName = "argsCode";

        // Act
        void attempt() => _ = argsCode.Defined(paramName);

        // Assert
        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(paramName, actual.ParamName);
    }

    [Fact]
    public void GetInvalidEnumArgumentException_returnsExpected()
    {
        // Arrange
        ArgsCode argsCode = default;
        string paramName = "argsCode";
        var exception = new InvalidEnumArgumentException();

        // Act
        var actual = argsCode.GetInvalidEnumArgumentException(paramName);

        // Assert
        Assert.IsType<InvalidEnumArgumentException>(actual);
    }
    #endregion
}
