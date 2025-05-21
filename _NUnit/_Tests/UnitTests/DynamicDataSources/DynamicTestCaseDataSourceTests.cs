// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicTestCaseDataSourceTests
{
    private DynamicTestCaseDataSourceChild _sut;

    #region OptionalToTestCaseData tests

    [Xunit.Theory, MemberData(nameof(OtionalToTestCaseDataTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void OptionalToTestCaseDatas_returnsExpected(ArgsCode argsCode, ArgsCode? tempArgsCode, Func<TestCaseData> testDataToTestCaseData, TestCaseData expected)
    {
        // Arrange
        _sut = new(argsCode);

        // Act
        var actual = _sut.OptionalToTestCaseData(testDataToTestCaseData, tempArgsCode);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    }

    [Fact]
    public void OptionalToTestCaseData_nullTestDataToArgs_throwsArgumentNullException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "testDataToTestCaseData";

        // Act
        void attempt() => _ = _sut.OptionalToTestCaseData(null, null);

        // Assert
        var actual = Xunit.Assert.Throws<ArgumentNullException>(attempt);
        Xunit.Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    #region TestDataToTestCaseData
    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToTestCaseData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }
    #endregion

    #region TestDataReturnsToTestCaseData
    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataReturnsToTestCaseData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataReturnsToTestCaseData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    }
    #endregion

    #region TestDataThrowsToTestCaseData
    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }

    [Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataThrowsToTestCaseData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataThrowsToTestCaseData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    }
    #endregion
}
