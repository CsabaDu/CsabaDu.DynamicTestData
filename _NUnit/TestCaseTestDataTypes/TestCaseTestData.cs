// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;

/// <summary>
/// Represents a test case data class for NUnit.
/// It inherits from <see cref="TestCaseData"/>
/// </summary>
public class TestCaseTestData : TestCaseData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestCaseTestData"/> class.
    /// <remark>
    /// The constructor sets the <see cref="TestParameters.Arguments"/> property.
    /// and the value of the <see cref="TestParameters.Description"/> key
    /// of the <see cref="TestParameters.Properties"/> dictionary.
    /// </remark>
    /// </summary>
    /// <param name="testData">The <see cref="TestData"/> instance having the necessary test parameters.</param>
    /// <param name="argsCode">The <see cref="ArgsCode"/> enum to determine the conversion method.</param>
    public TestCaseTestData(TestData testData, ArgsCode argsCode)
    : base(TestDataToParams(testData, argsCode))
    {
        Properties.Set(PropertyNames.Description, testData.TestCase);
        ExpectedResult = GetExpectedOrNull(testData);
    }

    /// <summary>
    /// Converts the specified test data into an array of parameters based on the provided argument code.
    /// </summary>
    /// <param name="testData">The test data to be converted. Cannot be <see langword="null"/>.</param>
    /// <param name="argsCode">The argument code that determines how the test data is processed.</param>
    /// <returns>An array of objects representing the parameters derived from the test data.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is <see langword="null"/>.</exception>
    internal static object?[] TestDataToParams(
        TestData testData,
        ArgsCode argsCode)
    => testData?.ToParams(argsCode, testData is not ITestDataReturns)
        ?? throw new ArgumentNullException(nameof(testData));

    /// <summary>
    /// Retrieves the expected value from the specified <see cref="TestData"/> instance,  or returns <see
    /// langword="null"/> if the instance does not implement <see cref="ITestDataReturns"/>.
    /// </summary>
    /// <param name="testData">The <see cref="TestData"/> instance from which to retrieve the expected value.</param>
    /// <returns>The expected value if <paramref name="testData"/> implements <see cref="ITestDataReturns"/>;  otherwise, <see
    /// langword="null"/>.</returns>
    internal static object? GetExpectedOrNull(TestData testData)
    => testData is ITestDataReturns testDataReturns ?
        testDataReturns.GetExpected()
        : null;
}
