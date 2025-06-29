﻿// SPDX-License-Identifier: MIT
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
        this ITestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    {
        object?[] args = TestDataToParams(
            testData,
            argsCode,
            testData is not ITestDataReturns,
            out string testCase);
        string? testName = GetDisplayName(testMethodName, testCase);

        var testCaseData = new TestCaseData(args)
            .SetDescription(testCase)
            .SetName(testName);

        return testData is ITestDataReturns testDataReturns ?
            testCaseData.Returns(testDataReturns.GetExpected())
            : testCaseData;
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
    public static TestCaseTestData ToTestCaseTestData<TTestData>(
        this TTestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    where TTestData : ITestData
    => new(testData, argsCode, testMethodName);
    #endregion
}
