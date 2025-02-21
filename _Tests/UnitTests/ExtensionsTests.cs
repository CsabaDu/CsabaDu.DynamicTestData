using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.ExtensionsTheoryData;
using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.SharedTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class ExtensionsTests
{
    private readonly object[] _sut = ExtensionsArgs0;

    #region object?[] extensions tests
    [Theory, MemberData(nameof(AddTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void Add_args_returnsExpected(ArgsCode argsCode, string parameter, object[] expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(argsCode, parameter);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange
        string expectedParamName = "argsCode";

        // Act
        void attempt() => _ = _sut.Add(InvalidArgsCode, Parameter);

        // Assert
        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region ArgsCode extensions tests
    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Defined_validArg_ArgsCode_returnsExpected(ArgsCode expected)
    {
        // Arrange & Act
        var actual = expected.Defined(null);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Defined_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange & Act
        void attempt() => _ = InvalidArgsCode.Defined(Parameter);

        // Assert
        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(Parameter, actual.ParamName);
    }

    [Fact]
    public void GetInvalidEnumArgumentException_returnsExpected()
    {
        // Arrange
        ArgsCode argsCode = default;

        // Act
        var actual = argsCode.GetInvalidEnumArgumentException(Parameter);

        // Assert
        Assert.IsType<InvalidEnumArgumentException>(actual);
        Assert.Equal(Parameter, actual.ParamName);
    }
    #endregion
}
