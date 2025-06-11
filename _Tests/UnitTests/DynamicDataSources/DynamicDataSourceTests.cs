// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DynamicDataSources;
using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSourceBase;
using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.DynamicDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicDataSourceTests
{
    private DynamicDataSourceBaseChild _sut;
    private DynamicToParamsChild _sutParams;

    #region Test Helpers
    private static void SetTempArgsCodeValue(DynamicDataSourceBase dataSource, ArgsCode? argsCode)
    => GetTempArgsCode(dataSource).Value = argsCode;

    private static AsyncLocal<ArgsCode?> GetTempArgsCode(DynamicDataSourceBase dataSource)
    {
        var field = typeof(DynamicDataSourceBase).GetField(
            TempArgsCodeName,
            BindingFlags.NonPublic | BindingFlags.Instance)
            ?? throw new MissingFieldException($"Field {TempArgsCodeName} not found");

        return (AsyncLocal<ArgsCode?>)field.GetValue(dataSource);
    }

    private static IDisposable CreateDisposableMemento(DynamicDataSourceBase dataSource, ArgsCode argsCode)
    {
        const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        var dataSourceType = typeof(DynamicDataSourceBase);
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
        var actual = new DynamicDataSourceBaseChild(argsCode);

        // Assert
        Assert.NotNull(actual);
        Assert.IsType<DynamicDataSourceBase>(actual, exactMatch: false);
        Assert.Equal(argsCode, actual.GetArgsCode());
    }

    [Fact]
    public void DynamicDataSource_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange & Act
        void attempt() => _ = new DynamicDataSourceBaseChild(InvalidArgsCode);

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
        object[] args = TestDataChildInstance.ToArgs(argsCode);
        string expected = $"{TestMethodName}(testData: {args[0]})";

        // Act
        var actual = GetDisplayName(TestMethodName, args);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(GetTestDisplayNameNullOrEmptyArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void GetdisplayName_nullArgs_returnsNull(string testMethodName, object[] args)
    {
        // Arrange
        _sut = new(default);

        // Act
        var actual = GetDisplayName(testMethodName, args);

        // Assert
        Assert.Null(actual);
    }
    #endregion

    #region WithOptionalArgsCode tests
    [Theory, MemberData(nameof(OtionalToParamsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void OptionalToParams_returnsExpected(ArgsCode argsCode, ArgsCode? tempArgsCode, Func<object[]> testDataToParams, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestWithOptionalArgsCode(_sut, testDataToParams, tempArgsCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OptionalToParams_nullTestDataToParams_throwsArgumentNullException()
    {
        // Arrange
        _sutParams = new(default);
        Func<object[]> testDataToParams = null;
        ArgsCode? tempArgsCode = default;
        string expectedParamName = "testDataToParams";

        // Act
        void attempt() => _ = _sutParams.TestWithOptionalArgsCode(_sutParams, testDataToParams, tempArgsCode);

        // Assert
        var actual = Assert.Throws<ArgumentNullException>(attempt);
        Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region TestDataToParams tests
    [Theory, MemberData(nameof(TestDataToParams1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataToParams9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataToParams_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region TestDataReturnsToParams tests
    [Theory, MemberData(nameof(TestDataReturnsToParams1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsToParams9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataReturnsToParams_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region TestDataThrowsToParams tests
    [Theory, MemberData(nameof(TestDataThrowsToParams1ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_1args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams2ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_2args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams3ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_3args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams4ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_4args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams5ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_5args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams6ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_6args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams7ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_7args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams8ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_8args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataThrowsToParams9ArgsTheoryData), MemberType = typeof(DynamicDataSourceTheoryData))]
    public void TestDataThrowsToParams_9args_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        _sutParams = new(argsCode);

        // Act
        var actual = _sutParams.TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);

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

    //[Theory, MemberData(nameof(OptionalArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
    //public void WithOptionalArgsCode_Action_WithArgsCode_CreatesMementoAndCallsGenerator(ArgsCode? argsCode)
    //{
    //    // Arrange
    //    _sut = new(default);
    //    var generatorCalled = false;

    //    Action testDataProcessor = () =>
    //    {
    //        generatorCalled = true;
    //    };

    //    // Act
    //    TestWithOptionalArgsCode(_sut, testDataProcessor, argsCode);

    //    // Assert
    //    Assert.True(generatorCalled);
    //}
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
