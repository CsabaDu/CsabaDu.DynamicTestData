// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using static CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources.TestCaseTestDataTheoryData;

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.TestCaseTestDataTypes;

public sealed class TestCaseTestDataTests
{
    [Fact]
    public void TestCaseTestData_nullArg_TestData_ThrowsArgumentNullException()
    {
        // Arrange & Act
        static void attempt() => _ = new TestCaseTestData(null!, default, null);

        // Assert
        var ex = Xunit.Assert.Throws<ArgumentNullException>(attempt);
        Xunit.Assert.Equal("testData", ex.ParamName);
    }

    [Fact]
    public void TestCaseTestData_invalidArg_ArgsCode_ThrowsInvalidEnumArgumentException()
    {
        // Arrange & Act
        static void attempt() => _ = new TestCaseTestData(TestDataArgs1, InvalidArgsCode, null);

        // Assert
        var ex = Xunit.Assert.Throws<InvalidEnumArgumentException>(attempt);
        Xunit.Assert.Equal("argsCode", ex.ParamName);
    }

    [Xunit.Theory, MemberData(nameof(TestCaseTestDataTheoryDataSource), MemberType = typeof(TestCaseTestDataTheoryData))]
    public void TestCaseTestData_ValidArgs_CreatesExpectedTestCaseTestData(
        TestData testData,
        ArgsCode argsCode,
        string testMethodName,
        object expectedResult)
    {
        // Arrange
        string testCase = testData.TestCase;
        string expectedTestName = GetDisplayName(testMethodName, testCase);
        object[] expectedArguments = testData.ToParams(argsCode, testData is not ITestDataReturns);

        // Act
        var actual = new TestCaseTestData(testData, argsCode, testMethodName);
        string description = actual.Properties.Get("Description") as string ?? string.Empty;

        // Assert
        Xunit.Assert.NotNull(actual);
        Xunit.Assert.Equal(testCase, description);
        Xunit.Assert.Equal(expectedArguments, actual.Arguments);
        Xunit.Assert.Equal(expectedTestName, actual.TestName);
        Xunit.Assert.Equal(expectedResult, actual.ExpectedResult);
    }
}
