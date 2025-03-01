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
namespace CsabaDu.DynamicTestData.xUnit.Tests.UnitTests;
public sealed class DynamicTheoryDataSourceTests
{
    private DynamicTheoryDataSourceChild _sut;

    [Fact]
    public void AddTestDataToTheoryData_Instance_AddsTestData()
    {
        // Arrange
        _sut = new(ArgsCode.Instance);
        string definition = "Test Definition";
        string expected = "Expected Result";
        int arg1 = 42;

        // Act
        _sut.AddTestDataToTheoryData(definition, expected, arg1);
        var actual = _sut.GetTheoryData();
        int count = actual.Count;
        //TestData<int> element = actual.GetEnumerator().Current;
        Type type = typeof(TheoryData<TestData<int>>);

        // Assert
        Assert.NotNull(actual);
        Assert.IsType(type, actual);
        Assert.Equal(1, count);
        //Assert.Equal(definition, element.Definition);
        //Assert.Equal(expected, element.Expected);
        //Assert.Equal(arg1, element.Arg1);
    }

    [Fact]
    public void AddTestDataToTheoryData_Properties_AddsArgument()
    {
        // Arrange
        var dataSource = new DynamicTheoryDataSourceChild(ArgsCode.Properties);
        int arg1 = 42;

        // Act
        dataSource.AddTestDataToTheoryData("Test Definition", "Expected Result", arg1);
        var actual = dataSource.GetTheoryData();
        //var element = (actual as IEnumerable<int?>).First();

        // Assert
        Assert.NotNull(actual);
        Assert.IsType<TheoryData<int>>(actual);
        Assert.Single(actual);
        //Assert.Equal(arg1, element);
    }
}
