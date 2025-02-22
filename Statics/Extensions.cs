﻿using static CsabaDu.DynamicTestData.DynamicDataSources.DynamicDataSource;

namespace CsabaDu.DynamicTestData.NUnit.Statics;

/// <summary>
/// Provides extension methods for converting test data to TestCaseData.
/// </summary>
public static class Extensions
{
    #region TestCaseData
    /// <summary>
    /// Converts an instance of ITestData to TestCaseData.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data.</returns>
    public static TestCaseData ToTestCaseData(this ITestData testData, ArgsCode argsCode, string? testMethodName = null)
    {
        TestCaseData testCaseData = argsCode switch
        {
            ArgsCode.Instance => new(testData),
            ArgsCode.Properties => new(testData.ToArgs(argsCode)[1..]),
            _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
        };
        string testCase = testData.TestCase;

        return string.IsNullOrEmpty(testMethodName) ?
            testCaseData.SetDescription(testCase)
            : testCaseData.SetDescription(testCase).SetName(GetDisplayName(testMethodName, testCase));
    }

    /// <summary>
    /// Converts an instance of ITestDataReturns<TStruct> to TestCaseData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return struct value.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>A TestCaseData object with the converted test data and expected return value.</returns>
    public static TestCaseData ToTestCaseData<TStruct>(this ITestDataReturns<TStruct> testData, ArgsCode argsCode, string? testMethodName = null) where TStruct : struct
    => (testData as ITestData).ToTestCaseData(argsCode, testMethodName).Returns(testData.Expected);
    #endregion
}
