// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

/// <summary>
/// Provides extension methods for converting test data to TestCaseData.
/// </summary>
public static class Extensions
{
    #region TestData
    /// <summary>
    /// Converts an instance of TestData to TestCaseData.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data.</returns>
    public static TestCaseData ToTestCaseData(
        this TestData testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    => GetTestCaseData(testData, argsCode, 1, testMethodName);
    #endregion

    #region TestDataReturns<TStruct>
    /// <summary>
    /// Converts an instance of TestDataReturns<TStruct> to TestCaseData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return struct value.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data and expected return value.</returns>
    public static TestCaseData ToTestCaseData<TStruct>(
        this TestDataReturns<TStruct> testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    where TStruct : struct
    => GetTestCaseData(testData, argsCode, 2, testMethodName).Returns(testData.Expected);
    #endregion

    #region Private methods
    private static TestCaseData GetTestCaseData(
        TestData testData,
        ArgsCode argsCode,
        int startIndex,
        string? testMethodName)
    {
        TestCaseData testCaseData = argsCode switch
        {
            ArgsCode.Instance => new(testData),
            ArgsCode.Properties => new(testData.ToArgs(argsCode)[startIndex..]),
            _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
        };
        string testCase = testData.TestCase;
        string? displayName = string.IsNullOrEmpty(testMethodName) ?
            null
            : GetDisplayName(testMethodName, testCase));

        return testCaseData
            .SetDescription(testCase)
            .SetName(displayName);
    }
    #endregion
}
