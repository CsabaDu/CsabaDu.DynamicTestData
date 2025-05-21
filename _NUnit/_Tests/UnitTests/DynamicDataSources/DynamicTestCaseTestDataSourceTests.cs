// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicTestCaseTestDataSourceTests
{
    private DynamicTestCaseTestDataSourceChild _sut;

    #region OptionalToTestCaseTestData tests

    //[Xunit.Theory, MemberData(nameof(OtionalToTestCaseTestDataTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void OptionalToTestCaseTestDatas_returnsExpected(ArgsCode argsCode, ArgsCode? tempArgsCode, Func<TestCaseData> testDataToTestCaseTestData, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new(argsCode);

    //    // Act
    //    var actual = _sut.OptionalToTestCaseTestData(testDataToTestCaseTestData, tempArgsCode);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //}

    [Fact]
    public void OptionalToTestCaseTestData_nullTestDataToArgs_throwsArgumentNullException()
    {
        // Arrange
        _sut = new(default);
        string expectedParamName = "testDataToTestCaseTestData";

        // Act
        void attempt() => _ = _sut.OptionalToTestCaseTestData(null, null);

        // Assert
        var actual = Xunit.Assert.Throws<ArgumentNullException>(attempt);
        Xunit.Assert.Equal(expectedParamName, actual.ParamName);
    }
    #endregion

    //#region TestDataToTestCaseTestData
    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataToTestCaseTestData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataToTestCaseTestData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataToTestCaseTestData(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    //}
    //#endregion

    //#region TestDataReturnsToTestCaseTestData
    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataReturnsToTestCaseTestData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataReturnsToTestCaseTestData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataReturnsToTestCaseTestData(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(DummyEnumTestValue, actual.ExpectedResult);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataReturnsDisplayName);
    //}
    //#endregion

    //#region TestDataThrowsToTestCaseTestData
    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData2ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_2args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData3ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_3args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData4ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_4args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData5ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_5args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData6ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_6args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData7ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_7args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData8ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_8args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}

    //[Xunit.Theory, MemberData(nameof(TestDataThrowsToTestCaseTestData9ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    //public void TestDataThrowsToTestCaseTestData_9args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    //{
    //    // Arrange
    //    _sut = new DynamicTestCaseTestDataSourceChild(argsCode);

    //    // Act
    //    var actual = _sut.TestDataThrowsToTestCaseTestData(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9, testMethodName);

    //    // Assert
    //    Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
    //    Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataThrowsDisplayName);
    //}
    //#endregion
}
