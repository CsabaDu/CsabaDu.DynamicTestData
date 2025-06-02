// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.Tests.UnitTests;

public class DynamicTheoryDataSourceTests
{
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
        _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.ResetTheoryData();

        // Assert
        Assert.Null(_sut.GetTheoryTestData());
    }
    #endregion

    #region AddOptional
    [Fact]
    public void AddOptional_differentArgsCode_addsDifferentTheoryTestDataRow_ArgsCodePropertyRemained()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        ArgsCode tempArgsCode = ArgsCode.Properties;
        _sut = new(argsCode);
        void add() => _sut.Add(ActualDefinition, ExpectedString, Arg1);


        // Act
        _sut.AddOptional(add, tempArgsCode);
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Equal(argsCode, _sut.GetArgsCode());
        Assert.Equal(tempArgsCode, actual.FirstOrDefault().ArgsCode);
    }

    [Fact]
    public void AddOptional_sameArgsCode_addsSameTheoryTestDataRow()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        _sut = new(argsCode);
        void add() => _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        _sut.AddOptional(add, argsCode);
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Equal(argsCode, _sut.GetArgsCode());
        Assert.Equal(argsCode, actual.FirstOrDefault().ArgsCode);
    }

    [Fact]
    public void AddOptional_nullArgsCode_addsSameTheoryTestDataRow()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        _sut = new(argsCode);
        void add() => _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        _sut.AddOptional(add, null);
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Equal(argsCode, _sut.GetArgsCode());
        Assert.Equal(argsCode, actual.FirstOrDefault().ArgsCode);
    }

    [Fact]
    public void AddOptional_differentArgsCodeTwice_addsDifferentTheoryTestDataRow_ArgsCodePropertyRemained()
    {
        // Arrange
        ArgsCode argsCode = ArgsCode.Instance;
        ArgsCode tempArgsCode = ArgsCode.Properties;
        _sut = new(argsCode);
        void add() => _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.AddOptional(add, tempArgsCode);
        _sut.AddOptional(add, tempArgsCode);
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Equal(argsCode, _sut.GetArgsCode());
        Assert.Equal(2, actual.Count());
        Assert.Equal(tempArgsCode, actual.FirstOrDefault().ArgsCode);
    }

    [Fact]
    public void AddOptional_nullTestDataToArgs_throwsArgumentNullException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "add";

        // Act
        void attempt() => _sut.AddOptional(null, null);

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
        void add() => _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        void attempt() => _sut.AddOptional(add, InvalidArgsCode);

        // Assert
        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region Add tests
    #region Different Types
    [Fact]
    public void Add_DifferentTypeArgs_CreatesNew()
    {
        // Arrange
        _sut = new(default);
        _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        _sut.Add(ActualDefinition, ExpectedString, Arg3);
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Single(actual);
        Assert.IsType<TheoryTestData<TestData<DateTime>>>(actual);
    }

    [Fact]
    public void Add_DifferentTypeArgCount_CreatesNew()
    {
        // Arrange
        _sut = new(default);
        _sut.Add(ActualDefinition, ExpectedString, Arg1);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.Single(actual);
        Assert.IsType<TheoryTestData<TestData<int, object>>>(actual);

    }
    #endregion

    #region Add Instance 1st
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_1st_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region Add Instance 2nd
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1);
        _sut.Add(ActualDefinition, ExpectedString, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Arrange
        _sut = new(argsCode);
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Arrange
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_2nd_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void Add_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sut.Add(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestData<int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count());
    }
    #endregion
    #endregion

    #region AddReturns tests
    #region AddReturns Instance 1st
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_1st_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region AddReturns Instance 2nd
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_2nd_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddReturns_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sut.AddReturns(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataReturns<DummyEnum, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count());
    }
    #endregion
    #endregion

    #region AddThrows tests
    #region AddThrows Instance 1st
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Single(actual);
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_1st_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Single(actual);
    }
    #endregion

    #region AddThrows Instance 2nd
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_1Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_2Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_3Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_4Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_5Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_2nd_6Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_7Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_8Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass>>>(actual);
        Assert.Equal(2, actual.Count());
    }

    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void AddThrows_9Args_Adds(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        _sut.AddThrows(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Act
        var actual = _sut.GetTheoryTestData();

        // Assert
        Assert.IsType<TheoryTestData<TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]>>>(actual);
        Assert.Equal(2, actual.Count());
    }
    #endregion
    #endregion
}