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
using Xunit;
using CsabaDu.DynamicTestData.xUnit.Attributes;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance
{
    private readonly DemoClass _sut = new();

    private const ArgsCode argsCode = ArgsCode.Instance;
    private static readonly TestDataToTheoryDataSource DataSource = new(argsCode);

    public static TheoryData<TestDataReturns<bool, DateTime, DateTime>>? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturnsToTheoryData() as TheoryData<TestDataReturns<bool, DateTime, DateTime>>;

    public static TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrowsToTheoryData() as TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>;

    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData)), ResetDataSource(nameof(DataSource), argsCode)]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsTheoryData)), ResetDataSource(nameof(DataSource), argsCode)]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(testData.Expected.ParamName, actual.ParamName);
        Assert.Equal(testData.Expected.Message, actual.Message);
    }
}
