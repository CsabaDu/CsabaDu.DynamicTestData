// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;
using static CsabaDu.DynamicTestData.TestHelpers.TestParameters.SharedTheoryData;
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.DynamicDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicDataSourceTests
{
    private DynamicDataSourceChild _sut;

    #region Test Helpers
    private static void SetTempArgsCodeValue(DynamicDataSource dataSource, ArgsCode? argsCode)
    => GetTempArgsCode(dataSource).Value = argsCode;

    private static AsyncLocal<ArgsCode?> GetTempArgsCode(DynamicDataSource dataSource)
    {
        var field = typeof(DynamicDataSource).GetField(
            TempArgsCodeName,
            BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new MissingFieldException($"Field {TempArgsCodeName} not found");

        return (AsyncLocal<ArgsCode?>)field.GetValue(dataSource);
    }

    private static IDisposable CreateDisposableMemento(DynamicDataSource dataSource, ArgsCode argsCode)
    {
        const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        var dataSourceType = typeof(DynamicDataSource);
        var disposableMemento = dataSourceType.GetNestedType(DisposableMementoName, bindingFlags)
            ?? throw new InvalidOperationException($"Could not find type: {DisposableMementoName}");
        var ctor = disposableMemento.GetConstructor(bindingFlags, null, [dataSourceType, typeof(ArgsCode)], null)
            ?? throw new MissingMethodException($"{DisposableMementoName} constructor");

        return (IDisposable)ctor.Invoke([dataSource, argsCode]);
    }

    private static TException AssertDisposableMementoThrows<TException>(Action attempt) where TException : Exception
    {
        var exception = Assert.Throws<TargetInvocationException>(attempt);
        var innerException = exception.InnerException
            ?? throw new InvalidOperationException("TargetInvocationException.InnerException was null");

        return Assert.IsType<TException>(innerException);
    }
    #endregion

    #region Constructor tests
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void DynamicDataSource_validArg_ArgsCode_createsInstance(ArgsCode argsCode)
    {
        // Arrange & Act
        var actual = new DynamicDataSourceChild(argsCode);

        // Assert
        Assert.NotNull(actual);
        Assert.IsType<DynamicDataSource>(actual, exactMatch: false);
        Assert.Equal(argsCode, actual.GetArgsCode());
    }

    [Fact]
    public void DynamicDataSource_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange & Act
        void attempt() => _ = new DynamicDataSourceChild(InvalidArgsCode);

        // Assert
        _ = Assert.Throws<InvalidEnumArgumentException>(attempt);
    }
    #endregion

    #region ArgsCode tests
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void ArgsCode_default_getsExpected(ArgsCode expected)
    {
        // Arrange
        _sut = new(expected);

        // Act
        var actual = _sut.GetArgsCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(ArgsCodesTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void ArgsCode_tempValue_getsExpected(ArgsCode argsCode, ArgsCode? tempArgsCode, ArgsCode expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        SetTempArgsCodeValue(_sut, tempArgsCode);
        var actual = _sut.GetArgsCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    #endregion

    #region GetDisplayName tests
    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void GetdisplayName_returnsExpected(ArgsCode argsCode)
    {
        // Arrange
        _sut = new(argsCode);
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
        _sut = new(default);
        string expected = null;

        // Act
        var actual = GetDisplayName(null, null);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region OptionalToArgs tests

    [Theory, MemberData(nameof(OtionalToArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void OptionalToArgs_returnsExpected(ArgsCode argsCode, ArgsCode? tempArgsCode, Func<object[]> testDataToArgs, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.OptionalToArgs(testDataToArgs, tempArgsCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OptionalToArgs_nullTestDataToArgs_throwsArgumentNullException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "testDataToArgs";

        // Act
        void attempt() => _ = _sut.OptionalToArgs(null, null);

        // Assert
        var actual = Assert.Throws<ArgumentNullException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region TestDataToArgs tests
    [Theory, MemberData(nameof(TestDataToArgs1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

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
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

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
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToArgs9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToArgs_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region WithOptionalArgsCode tests
    [Theory, MemberData(nameof(OptionalArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void WithOptionalArgsCode_Func_WithArgsCode_CreatesMementoAndCallsGenerator(ArgsCode? argsCode)
    {
        // Arrange
        _sut = new(default);
        var expected = ExpectedString;
        var generatorCalled = false;

        Func<string> testDataGenerator = () =>
        {
            generatorCalled = true;
            return expected;
        };

        // Act
        var actual = TestWithOptionalArgsCode(_sut, testDataGenerator, argsCode);

        // Assert
        Assert.True(generatorCalled);
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(OptionalArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    public void WithOptionalArgsCode_Action_WithArgsCode_CreatesMementoAndCallsGenerator(ArgsCode? argsCode)
    {
        // Arrange
        _sut = new(default);
        var generatorCalled = false;

        Action testDataProcessor = () =>
        {
            generatorCalled = true;
        };

        // Act
        TestWithOptionalArgsCode(_sut, testDataProcessor, argsCode);

        // Assert
        Assert.True(generatorCalled);
    }
    #endregion

    #region DisposableMemento tests
    #region Constructor tests
    [Fact]
    public void DisposableMemento_nullDynamicDataSource_ThrowsArgumentNullException()
    {
        // Arrange
        _sut = null;
        string expectedParamName = "dataSource";

        // Act
        void attempt() => _ = CreateDisposableMemento(_sut, default);

        // Assert
        var actual = AssertDisposableMementoThrows<ArgumentNullException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }

    [Fact]
    public void DisposableMemento_invalidArgsCode_ThrowsInvalidEnumArgumentException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "argsCode";

        // Act
        void attempt() => _ = CreateDisposableMemento(_sut, InvalidArgsCode);

        // Assert
        var actual = AssertDisposableMementoThrows<InvalidEnumArgumentException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region Memento tests
    [Fact]
    public void Memento_SetsNewValue_WhenCreated()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);

        // Act
        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
        {
            // Assert
            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
        }
    }
    [Fact]
    public async Task Memento_RespectsAsyncFlow()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);
        ArgsCode? asyncValue = null;

        // Act
        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
        {
            await Task.Run(() =>
            {
                asyncValue = _sut.GetArgsCode();
            });
        }

        // Assert
        Assert.Equal(ArgsCode.Instance, asyncValue); // Different async flow
        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
    }

    [Fact]
    public void Memento_WorksWithUsingStatement()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);

        // Act & Assert
        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
        {
            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
        }
        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
    }

    [Fact]
    public void Memento_RestoresNull_WhenOriginalWasNull()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);
        SetTempArgsCodeValue(_sut, null);

        // Act
        using (CreateDisposableMemento(_sut, ArgsCode.Instance))
        {
            Assert.Equal(ArgsCode.Instance, _sut.GetArgsCode());
        }

        // Assert
        Assert.Null(GetTempArgsCode(_sut).Value);
    }
    #endregion

    #region Dispose tests
    [Fact]
    public void Memento_RestoresOriginalValue_WhenDisposed()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);

        // Act
        var memento = CreateDisposableMemento(_sut, ArgsCode.Instance);
        memento.Dispose();

        // Assert
        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
    }

    [Fact]
    public void Memento_IsIdempotent_OnMultipleDisposes()
    {
        // Arrange
        _sut = new(ArgsCode.Properties);
        var memento = CreateDisposableMemento(_sut, ArgsCode.Instance);

        // Act
        memento.Dispose();
        memento.Dispose(); // Second dispose

        // Assert
        Assert.Equal(ArgsCode.Properties, _sut.GetArgsCode());
    }
    #endregion
    #endregion
}
