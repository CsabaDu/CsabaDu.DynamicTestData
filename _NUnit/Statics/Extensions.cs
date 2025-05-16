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
        _ = testData ?? throw new ArgumentNullException(nameof(testData));

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
    /// Converts an instance of <see cref="TestDataReturns{TStruct}"/> to <see cref="TestCaseTestData{TStruct}"/>.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return not null <see cref="ValueType"/> value.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseTestData{TStruct}"/> instance with the converted test data and expected return value.
    /// </returns>
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
        return testData is ITestDataThrows ?
            getTestCaseData(true)
            : getTestCaseData(false);

        #region Local methods
        TestCaseData getTestCaseData(bool withExpected)
        => GetTestCaseData(testData, argsCode, withExpected, testMethodName);
        #endregion
    }
    #endregion

    #region TestDataReturns<TStruct>
    /// <summary>
    /// Converts an instance of <see cref="TestDataReturns{TStruct}"/> to <see cref="TestCaseData"/>.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return struct value.</typeparam>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseData"/> instance with the converted test data and expected return value.
    /// </returns>
    public static TestCaseData ToTestCaseData<TStruct>(
        this TestDataReturns<TStruct> testData,
        ArgsCode argsCode,
        string? testMethodName = null)
    where TStruct : struct
    => GetTestCaseData(testData, argsCode, true, testMethodName)
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
        bool withExpected,
        string? testMethodName)
    {
        TestCaseData testCaseData = argsCode switch
        {
            ArgsCode.Instance => new(testData),
            ArgsCode.Properties => new(testData.PropertiesToArgs(withExpected)),
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
