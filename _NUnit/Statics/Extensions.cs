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
    /// Converts an instance of TestData to an array of arguments.
    /// This method used solely to set the <see cref="TestParameters.Arguments"/> property
    /// in the constructor of <see cref="TestCaseTestData"/>.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <returns>
    /// A new array of arguments with the properties of <paramref name="testData"/>
    /// if the argument code is <see cref="ArgsCode.Properties"/>
    /// otherwise an object array with the instance of <paramref name="testData"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Throws if <paramref name="testData"/> is null.</exception>
    /// <exception cref="InvalidEnumArgumentException">" if <paramref name="argsCode"/> is not a valid enum value.</exception>
    internal static object?[] ToArguments(this TestData testData, ArgsCode argsCode)
    {
        ArgumentNullException.ThrowIfNull(testData, nameof(testData));

        return argsCode switch
        {
            ArgsCode.Instance => [testData],
            ArgsCode.Properties => testData is ITestDataThrows ?
                testData.PropertiesToArgs(true)
                : testData.PropertiesToArgs(false),
            _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
        };
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
        TestName = GetTestName(testData, testMethodName),
    };

    /// <summary>
    /// Converts an instance of <see cref="TestData"/> to <see cref="TestCaseData"/>.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseData"/> instance with the converted test data.
    /// </returns>
    public static TestCaseData ToTestCaseData(
        this TestData testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    {
        ArgumentNullException.ThrowIfNull(testData, nameof(testData));

        TestCaseData testCaseData = argsCode switch
        {
            ArgsCode.Instance => new(testData),
            ArgsCode.Properties => new(testData.PropertiesToArgs(testData is ITestDataThrows)),
            _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
        };

        if (testData is ITestDataReturns testDataReturns)
        {
            testCaseData.Returns(testDataReturns.GetExpected());
        }

        string? displayName = GetTestName(testData, testMethodName);

        return testCaseData
            .SetDescription(testData.TestCase)
            .SetName(displayName);
    }
    #endregion

    #region Private methods
    private static string? GetTestName(
        TestData testData,
        string? testMethodName)
    => !string.IsNullOrEmpty(testMethodName) ?
        GetDisplayName(testMethodName, testData.TestCase)
        : null;

    //private 
    #endregion
}
