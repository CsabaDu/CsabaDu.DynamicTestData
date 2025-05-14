// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;
using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

/// <summary>
/// Provides extension methods for converting test data to TestCaseData.
/// </summary>
public static class Extensions
{
    #region TestData
    internal static object?[] ToArguments(this TestData testData, ArgsCode argsCode)
    {
        _ = testData ?? throw new ArgumentNullException(nameof(testData));

        return argsCode switch
        {
            ArgsCode.Instance => [testData],
            ArgsCode.Properties => testData is ITestDataThrows ?
                testDataPropertiesToArgs(1)
                : testDataPropertiesToArgs(2),
            _ => throw DynamicTestData.Statics.Extensions
                .GetInvalidEnumArgumentException(argsCode, nameof(argsCode)),
        };

        object?[] testDataPropertiesToArgs(int startIndex)
        => testData.ToArgs(ArgsCode.Properties)[startIndex..];
    }

    public static TestCaseTestData ToTestCaseTestData(
        this TestData testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    => new(testData, argsCode)
    {
        TestName = GetTestName(testData, testMethodName),
    };

    public static TestCaseTestData<TStruct> ToTestCaseTestData<TStruct>(
        this TestDataReturns<TStruct> testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    where TStruct : struct
    => new(testData, argsCode)
    {
        TestName = GetTestName(testData, testMethodName),
    };

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
    {
        return testData switch
        {
            ITestDataThrows => getTestCaseData(1),
            _ => getTestCaseData(2),
        };

        TestCaseData getTestCaseData(int startIndex)
        => GetTestCaseData(testData, argsCode, startIndex, testMethodName);
    }
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
    => GetTestCaseData(testData, argsCode, 2, testMethodName)
        .Returns(testData.Expected);
    #endregion

    #region Private methods
    private static string? GetTestName(
        TestData testData,
        string? testMethodName)
    => testMethodName is not null ?
        GetDisplayName(testMethodName, testData.TestCase)
        : null;

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
            : GetDisplayName(testMethodName, testCase);

        return testCaseData
            .SetDescription(testCase)
            .SetName(displayName);
    }
    #endregion
}
