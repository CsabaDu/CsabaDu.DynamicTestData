﻿namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class DynamicDataSourceTests
{
    private readonly DynamicDataSourceChild _sutInstance = new(ArgsCode.Instance);
    private readonly DynamicDataSourceChild _sutProperties = new(ArgsCode.Properties);
    private readonly object[] TestDataReturnsArgs0 = [TestDataReturnsTestCase, DummyEnumTestValue];

    #region TestDataToArgs tests
    #region ArgsCode.Instance   
    [Fact]
    public void TestDataToArgs_Instance_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs1];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs2];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs3];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs4];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs5];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs6];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs7];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs8];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataArgs9];

        // Act
        var actual = _sutInstance.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region ArgsCode.Properties
    [Fact]
    public void TestDataToArgs_Properties_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, Arg1];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args2];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args3];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args4];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args5];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args6];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args7];
        // Act

        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, ..Args8];

        // Act

        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataTestCase, .. Args9];

        // Act
        var actual = _sutProperties.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region TestDataReturnsToArgs tests
    #region ArgsCode.Instance
    [Fact]
    public void TestDataReturnsToArgs_Instance_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs1];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs2];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs3];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs4];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs5];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs6];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs7];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs8];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Instance_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataReturnsArgs9];

        // Act
        var actual = _sutInstance.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region ArgsCode.Properties
    [Fact]
    public void TestDataReturnsToArgs_Properties_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, Arg1];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args2];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args3];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args4];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args5];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args6];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args7];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args8];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataReturnsToArgs_Properties_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataReturnsArgs0, .. Args9];

        // Act
        var actual = _sutProperties.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion
}
