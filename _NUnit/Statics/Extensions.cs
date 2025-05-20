// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.Statics;

/// <summary>
/// Provides extension methods for converting test data to TestCaseData.
/// </summary>
public static class Extensions
{
    #region TestData
    /// <summary>
    /// Converts an instance of <see cref="TestData"/> to <see cref="TestCaseData"/>.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseData"/> instance with the converted test data.
    /// </returns>
    /// <exception cref="ArgumentNullException">Throws if <paramref name="testData"/> is null.</exception>
    /// <exception cref="InvalidEnumArgumentException">" if <paramref name="argsCode"/> is not a valid enum value.</exception>
    public static TestCaseData ToTestCaseData(
        this TestData testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    {
        object?[] args = TestDataToParams(
            testData,
            argsCode,
            testData is not ITestDataReturns,
            out string testCase);
        object? expected = GetExpectedOrNull(testData);
        string? testName = GetDisplayName(testMethodName, testCase);

        return new TestCaseData(args)
            .SetDescription(testCase)
            .SetName(testName)
            .Returns(expected);
    }

    /// <summary>
    /// Converts an instance of <see cref="TestData"/> to <see cref="TestCaseTestData"/>.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseTestData"/> instance with the converted test data.
    /// </returns>
    public static TestCaseTestData ToTestCaseTestData(
        this TestData testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    => new(testData, argsCode)
    {
        TestName = GetDisplayName(testMethodName, testData.TestCase),
    };
    #endregion
}
