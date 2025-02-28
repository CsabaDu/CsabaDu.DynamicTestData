/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.ExtensionsTheoryData;
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.SharedTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.Statics;

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
