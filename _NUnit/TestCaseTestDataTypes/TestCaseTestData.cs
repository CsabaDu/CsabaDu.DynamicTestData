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
    internal TestCaseTestData(
        TestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    : base(TestDataToParams(
        testData, argsCode,
        testData is not ITestDataReturns,
        out string testCase))
    {
        Properties.Set(PropertyNames.Description, testCase);
        TestName = GetDisplayName(testMethodName, testCase);

        if (testData is ITestDataReturns testDataReturns)
        {
            ExpectedResult = testDataReturns.GetExpected();
        }
    }
}
