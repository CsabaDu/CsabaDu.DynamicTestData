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
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.TestDataReturnsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataReturnsTests
{
    private ITestData _sut;

    private static TestDataReturnsChild<TStruct> GetTestDataReturnsChild<TStruct>(string definition, TStruct expected)
        where TStruct : struct
    => new(definition, expected);

    #region Abstract TestDataReturns tests
    #region Properties tests
    [Fact]
    public void ExitMode_getsExpected()
    {
        // Arrange
        _sut = TestDataReturnsChildInstance;
        string expected = TestData.Returns;

        // Act
        var actual = _sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Expected_getsExpected()
    {
        // Arrange
        var sut = TestDataReturnsChildInstance;
        DummyEnum expected = DummyEnumTestValue;

        // Act
        var actual = sut.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(ReturnsTheoryData), MemberType = typeof(TestDataReturnsTheoryData))]
    public void Result_getsExpected<TStruct>(TStruct expectedStruct, string expected) where TStruct : struct
    {
        // Arrange
        _sut = GetTestDataReturnsChild(null, expectedStruct);

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestCase_getsExpected()
    {
        // Arrange
        _sut = TestDataReturnsChildInstance;
        string expectedString = DummyEnumTestValue.ToString();
        string exitModeResult = GetExitModeResult(TestData.Returns, expectedString);
        string expected = GetTestDataTestCase(ActualDefinition, exitModeResult);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestDataReturns tests
    #region Methods tests
    [Theory, MemberData(nameof(ToArgsTheoryData), MemberType = typeof(TestDataReturnsTheoryData))]
    public void ToArgs_args_returnsExpected(ArgsCode argsCode, ITestDataReturns<DummyEnum> sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(argsCode);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion
}
