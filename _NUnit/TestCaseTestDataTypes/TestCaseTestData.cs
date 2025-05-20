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
    : base(TestDataToParams(
        testData, argsCode,
        testData is not ITestDataReturns,
        out string testCase))
    {
        Properties.Set(PropertyNames.Description, testCase);
        ExpectedResult = GetExpectedOrNull(testData);
    }

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
