// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestDataHolders;

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
            out string testCaseName);
        string? testName = GetDisplayName(testMethodName, testCaseName);

        var testCaseData = new TestCaseData(args)
            .SetDescription(testCaseName)
            .SetName(testName);

        var testDataReturns = testData as ITestDataReturns;
        testCaseData.HasExpectedResult = testDataReturns != null;

        if (argsCode == ArgsCode.Properties)
        {
            Type[] genericTypes =
                testData.GetType().GetGenericArguments();

            testCaseData.TypeArgs = testCaseData.HasExpectedResult ?
                genericTypes[1..]
                : genericTypes;
        }

        return testCaseData.HasExpectedResult ?
            testCaseData.Returns(testDataReturns!.GetExpected())
            : testCaseData;
    }

    /// <summary>
    /// Determines whether the specified <see cref="ITestData"/> instance implements the <see cref="ITestDataReturns"/>
    /// interface.
    /// </summary>
    /// <param name="testData">The <see cref="ITestData"/> instance to check.</param>
    /// <param name="testDataReturns">When this method returns, contains the <see cref="ITestDataReturns"/> instance if <paramref name="testData"/>
    /// implements the interface; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="testData"/> implements the <see cref="ITestDataReturns"/> interface;
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsTestDataReturns(
        this ITestData testData,
        out ITestDataReturns? testDataReturns)
    {
        testDataReturns = testData as ITestDataReturns;
        return testDataReturns != null;
    }

    /// <summary>
    /// Converts an instance of <see cref="TestData"/> to <see cref="TestCaseDataRow"/>.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <param name="argsCode">The ArgsCode to determine the conversion method.</param>
    /// <param name="testMethodName">Optional. The name of the test method.</param>
    /// <returns>
    /// A <see cref="TestCaseDataRow"/> instance with the converted test data.
    /// </returns>
    public static TestCaseDataRow<TTestData> ToTestCaseTestData<TTestData>(
        this TTestData testData,
        ArgsCode argsCode)
    where TTestData : notnull, ITestData
    => new(testData, argsCode);
    #endregion
}
