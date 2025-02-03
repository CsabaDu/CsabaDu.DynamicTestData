﻿using static CsabaDu.DynamicTestData.DynamicDataSource;
using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.DynamicDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class DynamicDataSourceTests
{
    private readonly DynamicDataSourceChild _sutInstance = new(ArgsCode.Instance);
    private readonly DynamicDataSourceChild _sutProperties = new(ArgsCode.Properties);

    #region GetDisplayName tests
    [Theory, MemberData(nameof(GetDisplayNameTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void GetdisplayName_returnsExpected(ArgsCode argsCode)
    {
        // Arrange
        string testMethodName = nameof(DummyClass.DummyMethod);
        MethodInfo testMethod = typeof(DummyClass).GetMethod(testMethodName);
        object[] args = TestDataChildInstance.ToArgs(argsCode);
        string expected = $"{testMethod.Name}(testData: {args[0] as string})";

        // Act
        string actual = GetDisplayName(testMethod, args);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

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

    #region TestDataThrowsToArgs tests
    #region ArgsCode.Instance
    [Fact]
    public void TestDataThrowsToArgs_Instance_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs1];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs2];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs3];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs4];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs5];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs6];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs7];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs8];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Instance_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [TestDataThrowsArgs9];

        // Act
        var actual = _sutInstance.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region ArgsCode.Properties
    [Fact]
    public void TestDataThrowsToArgs_Properties_1args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, Arg1];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_2args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args2];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_3args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args3];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_4args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args4];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_5args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args5];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_6args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args6];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_7args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args7];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_8args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args8];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataThrowsToArgs_Properties_9args_returnsExpected()
    {
        // Arrange
        object[] expected = [.. TestDataThrowsArgs0, .. Args9];

        // Act
        var actual = _sutProperties.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Parameter, ErrorMessage, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion
}
