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

public class DynamicTheoryDataSourceTests
{
    private readonly DynamicTheoryDataSourceChild _sutInstance = new(ArgsCode.Instance);
    private readonly DynamicTheoryDataSourceChild _sutProperties = new(ArgsCode.Properties);
    private DynamicTheoryDataSourceChild _sut;

    #region Constructor tests
    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Constructor_validArg_ArgsCode_createsInstance(ArgsCode argsCode)
    {
        // Arrange & Act
        var sut = new DynamicTheoryDataSourceChild(argsCode);

        // Assert
        Assert.NotNull(sut);
        Assert.IsType<DynamicTheoryDataSource>(sut, exactMatch: false);
    }

    [Fact]
    public void Constructor_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange & Act
        static void attempt() => _ = new DynamicTheoryDataSourceChild(InvalidArgsCode);

        // Assert
        _ = Assert.Throws<InvalidEnumArgumentException>(attempt);
    }
    #endregion

    #region ResetTheoryData
    [Fact]
    public void ResetTheoryData_SetsTheoryDataToNull()
    {
        // Arrange
        _sut = new(default);
        _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.ResetTheoryData();

        // Assert
        Assert.Null(_sut.GetTheoryData());
    }
    #endregion

    #region GetArgumentsMismatchMessage
    [Fact]
    public void GetArgumentsMismatchMessage_ReturnsExpected()
    {
        // Arrange
        string actualTypeName = typeof(TheoryData<int, string>).Name;
        string expectedTypeName = typeof(TheoryData<TheoryData<TestData<int>>>).Name;
        _sut = new DynamicTheoryDataSourceChild(default);
        _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
        string expected = ArgumentsAreSuitableForCreating + actualTypeName +
              ElementsAndDoNotMatchWithTheInitiated + expectedTypeName + InstancesTypeParameters;

        // Act
        var actual = _sut.GetArgumentsMismatchMessage<TheoryData<int, string>>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region AddTestDataToTheoryData Instance 1st
    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        // Act
        var actual = _sutInstance.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region AddTestDataToTheoryData Instance 2nd
    [Fact]
    public void AddTestDataToTheoryData__2nd_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData__2nd_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData__2nd_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData__2nd_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void Add2ndsTestDataToTheoryData_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void Add2ndsTestDataToTheoryData_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddsTestDataToTheoryData_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddsTestDataToTheoryData_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddsTestDataToTheoryData_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion

    #region AddTestDataToTheoryData Properties 1st
    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string, double>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string, double, bool>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string, double, bool, char>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string, double, bool, char, DummyClass>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData__1st_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>(actual);
        Assert.Single(actual);
    }
    #endregion
}
