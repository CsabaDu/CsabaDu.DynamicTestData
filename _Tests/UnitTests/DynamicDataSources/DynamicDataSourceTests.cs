﻿using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.DynamicDataSourceTheoryData;
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.SharedTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicDataSourceTests
{
    private DynamicDataSource _sut;

    #region Constructor tests
    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Constructor_validArg_ArgsCode_createsInstance(ArgsCode argsCode)
    {
        // Arrange & Act
        var actual = new DynamicDataSourceChild(argsCode);

        // Assert
        Assert.NotNull(actual);
        Assert.IsType<DynamicDataSource>(actual, exactMatch: false);
    }

    [Fact]
    public void Constructor_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange & Act
        void attempt() => _ = new DynamicDataSourceChild(InvalidArgsCode);

        // Assert
        _ = Assert.Throws<InvalidEnumArgumentException>(attempt);
    }
    #endregion

    #region GetDisplayName tests
    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(SharedTheoryData))]
    public void GetdisplayName_returnsExpected(ArgsCode argsCode)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);
        string testMethodName = "Test Method Name";
        object[] args = TestDataChildInstance.ToArgs(argsCode);
        string expected = $"{testMethodName}({args[0]})";

        // Act
        var actual = GetDisplayName(testMethodName, args);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetdisplayName_nullArgs_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(default);
        string expected = $"{null}({null})";

        // Act
        var actual = GetDisplayName(null, null);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region TestDataToArgs tests
    [Theory, MemberData(nameof(TestDataToArgs1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region TestDataReturnsToArgs tests
    [Theory, MemberData(nameof(TestDataReturnsToArgs1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region TestDataThrowsToArgs tests
    [Theory, MemberData(nameof(TestDataThrowsToArgs1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new DynamicDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
}
