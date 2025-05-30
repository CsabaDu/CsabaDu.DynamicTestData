﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)


namespace CsabaDu.DynamicTestData.xUnit.Tests.UnitTests;

public class DynamicTheoryDataSourceTests
{
    private readonly DynamicTheoryDataSourceChild _sutInstance = new(ArgsCode.Instance);
    private readonly DynamicTheoryDataSourceChild _sutProperties = new(ArgsCode.Properties);
    private DynamicTheoryDataSourceChild _sut;

    #region Constructor tests
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
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

    #region ResetTheoryData tests
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

    #region AddOptionalToTheoryData
    [Fact]
    public void AddOptional_differentArgsCode_addsDifferentTheoryData_ArgsCodePropertyRemained()
    {
        // Arrange
        ArgsCode expectedArgsCode = ArgsCode.Instance;
        ArgsCode tempArgsCode = ArgsCode.Properties;
        _sut = new(expectedArgsCode);
        TheoryData<int> expectedTheoryData = new(Arg1);
        void addTestDataToTheoryData() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.AddOptionalToTheoryData(addTestDataToTheoryData, tempArgsCode);

        // Assert
        Assert.Equal(expectedArgsCode, _sut.GetArgsCode());
        Assert.Equal(expectedTheoryData, _sut.GetTheoryData());
    }

    [Fact]
    public void AddOptional_sameArgsCode_addsSameTheoryData()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        _sut = new(argsCode);
        TestDataReturns<DummyEnum, int> testDataReturns = new(ActualDefinition, DummyEnumTestValue, Arg1);
        TheoryData<TestDataReturns<DummyEnum, int>> expectedTheoryData = new(testDataReturns);
        void addTestDataToTheoryData() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        _sut.AddOptionalToTheoryData(addTestDataToTheoryData, argsCode);

        // Assert
        Assert.Equal(expectedTheoryData, _sut.GetTheoryData());
    }

    [Fact]
    public void AddOptional_nullArgsCode_addsSameTheoryData()
    {
        // Arrange
        _sut = new(ArgsCode.Instance);
        TestDataThrows<DummyException, int> testDataThrows = new(ActualDefinition, DummyExceptionInstance, Arg1);
        TheoryData<TestDataThrows<DummyException, int>> expectedTheoryData = new(testDataThrows);
        void addTestDataToTheoryData() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        _sut.AddOptionalToTheoryData(addTestDataToTheoryData, null);

        // Assert
        Assert.Equal(expectedTheoryData, _sut.GetTheoryData());
    }

    [Fact]
    public void AddOptional_differentArgsCodeTwice_addsDifferentTheoryData_ArgsCodePropertyRemained()
    {
        // Arrange
        ArgsCode expectedArgsCode = ArgsCode.Instance;
        ArgsCode tempArgsCode = ArgsCode.Properties;
        _sut = new(expectedArgsCode);
        TheoryData<int> expectedTheoryData = new(Arg1) { Arg1 };
        void addTestDataToTheoryData() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.AddOptionalToTheoryData(addTestDataToTheoryData, tempArgsCode);
        _sut.AddOptionalToTheoryData(addTestDataToTheoryData, tempArgsCode);

        // Assert
        Assert.Equal(expectedArgsCode, _sut.GetArgsCode());
        Assert.Equal(expectedTheoryData, _sut.GetTheoryData());
    }

    [Fact]
    public void AddOptional_nullTestDataToArgs_throwsArgumentNullException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "addOptionalToTheoryData";

        // Act
        void attempt() => _sut.AddOptionalToTheoryData(null, null);

        // Assert
        var actual = Assert.Throws<ArgumentNullException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }

    [Fact]
    public void AddOptional_invalidArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "argsCode";
        void addTestDataToTheoryData() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        void attempt() => _sut.AddOptionalToTheoryData(addTestDataToTheoryData, InvalidArgsCode);

        // Assert
        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region AddTestDataToTheoryData tests
    #region Add Instance 1st
    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region Add Instance 2nd
    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutInstance.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion

    #region Add Properties 1st
    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args1Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args2Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args3Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args4Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args5Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args6Types));
        Assert.Single(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args7Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args8Types));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataToTheoryData_1st_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(Args9Types));
        Assert.Single(actual);
    }
    #endregion

    #region Add Properties 2nd
    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataToTheoryData_2nd_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutProperties.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion
    #endregion

    #region AddTestDataReturnsToTheoryData tests
    #region AddTestDataReturnsToTheoryData Instance 1st
    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region AddTestDataReturnsToTheoryData Instance 2nd
    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutInstance.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion

    #region AddTestDataReturnsToTheoryData Properties 1st
    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args1Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args2Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args3Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args4Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args5Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args6Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args7Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args8Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_1st_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        // Act
        var actual = _sutProperties.GetTheoryData();
        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetReturnsTypes(Args9Types)));
        Assert.Single(actual);
    }
    #endregion

    #region AddTestDataReturnsToTheoryData Properties 2nd
    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataReturnsToTheoryData_2nd_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutProperties.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion
    #endregion

    #region AddTestDataThrowsToTheoryData tests
    #region AddTestDataThrowsToTheoryData Instance 1st
    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region AddTestDataThrowsToTheoryData Instance 2nd
    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_1Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_2Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_3Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_4Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_5Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Instance_6Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_Instance_7Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_Instance_8Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_Instance_9Args_Adds()
    {
        // Arrange
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutInstance.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutInstance.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion

    #region AddTestDataThrowsToTheoryData Properties 1st
    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args1Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args2Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args3Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args4Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args5Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args6Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args7Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args8Types)));
        Assert.Single(actual);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_1st_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.True((actual as TheoryTestData).Equals(GetThrowsTypes(Args9Types)));
        Assert.Single(actual);
    }
    #endregion

    #region AddTestDataThrowsToTheoryData Properties 2nd
    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_1Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_2Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_3Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_4Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_5Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_6Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_7Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_8Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }

    [Fact]
    public void AddTestDataThrowsToTheoryData_2nd_Properties_9Args_Adds()
    {
        // Arrange
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sutProperties.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sutProperties.GetTheoryData();

        // Assert
        Assert.IsType<TheoryTestData>(actual);
        Assert.Equal(2, actual.Count);
    }
    #endregion
    #endregion
}

    //private static readonly string ArgsCodePropertyHasInvalidValueMessage = ArgsCodePropertyHasInvalidValue_ + 2;

    //private void SetSutArgsCodeWithInvalidValue()
    //{
    //    _sut = new(default);
    //    _sut.SetArgsCodeWithInvalidValue();
    //}

    //#region ArgumentsMismatchMessageEnd tests
    //[Fact]
    //public void ArgumentsMismatchMessageEnd_getsExpected()
    //{
    //    // Arrange
    //    _sut = new(default);
    //    string theoryDataName = _sut.GetTheoryData()?.GetType().Name;
    //    var expected = " elements and do not match with the initiated "
    //        + theoryDataName + " instance's type parameters.";

    //    // Act
    //    var actual = _sut.ArgumentsMismatchMessageEnd;

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}
    //#endregion

    //#region GetArgumentsMismatchMessage tests
    //[Fact]
    //public void GetArgumentsMismatchMessage_returnsExpected()
    //{
    //    // Arrange
    //    string actualTypeName = typeof(TheoryData<int, string>).Name;
    //    _sut = new DynamicTheoryDataSourceChild(default);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);
    //    string expected = ArgumentsAreSuitableForCreating_ + actualTypeName +
    //          _sut.ArgumentsMismatchMessageEnd;

    //    // Act
    //    var actual = _sut.GetArgumentsMismatchMessage<TheoryData<int, string>>();

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}
    //#endregion

    //#region AddTestDataToTheoryData throws ArgumentException
    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_1Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_2Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);

    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_3Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_4Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_5Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_6Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_7Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_8Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataToTheoryData_9Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}
    //#endregion

    //#region AddTestDataToTheoryData throws InvalidOperationException
    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_1Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_2Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_3Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_4Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_5Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_6Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_7Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_8Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataToTheoryData_invalidArgsCode_9Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataToTheoryData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}
    //#endregion

    //#region AddTestDataReturnsToTheoryData throws ArgumentException
    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_1Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_2Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);

    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_3Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_4Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_5Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_6Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_7Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_8Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataReturnsToTheoryData_9Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}
    //#endregion

    //#region AddTestDataReturnsToTheoryData throws InvalidOperationException
    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_1Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_2Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_3Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_4Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AAddTestDataReturnsToTheoryData_invalidArgsCode_5Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_6Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_7Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_8Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataReturnsToTheoryData_invalidArgsCode_9Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataReturnsToTheoryData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}
    //#endregion

    //#region AddTestDataThrowsToTheoryData throws ArgumentException
    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_1Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_2Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_3Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_4Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_5Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_6Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_7Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_8Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}

    //[Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void AddTestDataThrowsToTheoryData_9Args_invalidArgs_throwsArgumentException(ArgsCode argsCode)
    //{
    //    // Arrange
    //    _sut = new(argsCode);
    //    _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, DummyEnumTestValue);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentException>(attempt);
    //    Assert.StartsWith(ArgumentsAreSuitableForCreating_, actual.Message);
    //}
    //#endregion

    //#region AddTestDataThrowsToTheoryData throws InvalidOperationException
    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_1Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_2Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_3Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_4Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AAddTestDataThrowsToTheoryData_invalidArgsCode_5Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_6Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_7Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_8Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}

    //[Fact]
    //public void AddTestDataThrowsToTheoryData_invalidArgsCode_9Args_throwsInvalidOperationException()
    //{
    //    // Arrange
    //    SetSutArgsCodeWithInvalidValue();

    //    // Act
    //    void attempt() => _sut.AddTestDataThrowsToTheoryData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

    //    // Assert
    //    var actual = Assert.Throws<InvalidOperationException>(attempt);
    //    Assert.Equal(ArgsCodePropertyHasInvalidValueMessage, actual.Message);
    //}
    //#endregion