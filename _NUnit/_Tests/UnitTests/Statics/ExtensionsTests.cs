// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;
using static CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources.ExtensionsTheoryData;

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.Statics;

public sealed class ExtensionsTests
{
    private TestData _sut;

    #region ToTestCaseData Tests
    [Fact]
    public void ToTestCaseData_nullArg_TestData_throwsArgumentNullException()
    {
        // Arrange
        _sut = null;
        string expectedParamName = "testData";

        // Act
        void attempt() => _ = Extensions.ToTestCaseData(null, default, null);

        // Assert
        var actual = Xunit.Assert.Throws<ArgumentNullException>(attempt);
        Xunit.Assert.Equal(expectedParamName, actual.ParamName);
    }

    [Fact]
    public void ToTestCaseData_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange
        _sut = TestDataChildInstance;
        string expectedParamName = "argsCode";

        // Act
        void attempt() => _ = _sut.ToTestCaseData(InvalidArgsCode, null);

        // Assert
        var actual = Xunit.Assert.Throws<InvalidEnumArgumentException>(attempt);
        Xunit.Assert.Equal(expectedParamName, actual.ParamName);
    }

    [Xunit.Theory, MemberData(nameof(ToTestCaseDataTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void ToTestCaseData_validArg_ArgsCode_returnsExpected(TestData sut, ArgsCode argsCode, TestCaseData expected)
    {
        // Arrange
        static object getDescription(TestCaseData testCaseData)
        => testCaseData.Properties.Get("Description");

        bool isTestDataReturns = sut is ITestDataReturns;
        object expectedResult = isTestDataReturns ? DummyEnumTestValue : null;

        // Act
        var actual = sut.ToTestCaseData(argsCode, null);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(getDescription(expected), getDescription(actual));
        Xunit.Assert.Equal(expectedResult, actual.ExpectedResult);
        Xunit.Assert.Equal(isTestDataReturns, actual.HasExpectedResult);
        Xunit.Assert.Null(actual.TestName);
    }

    [Xunit.Theory, MemberData(nameof(ToTestCaseDataSetNameTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void ToTestCaseData_arg_testMethodName_returnsExpected(string testMethodName)
    {
        // Arrange
        _sut = TestDataChildInstance;
        string expected = DynamicDataSource.GetDisplayName(testMethodName, _sut);

        // Act
        var actual = _sut.ToTestCaseData(default, testMethodName).TestName;

        // Assert
        Xunit.Assert.Equal(expected, actual);
    }
    #endregion
}
