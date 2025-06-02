// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;

/// <summary>
/// Represents a test case data class for NUnit.
/// It inherits from <see cref="TestCaseData"/>
/// </summary>
public abstract class TestCaseTestData
: TestCaseData
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
    private protected TestCaseTestData(
        ITestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    : base(TestDataToParams(
        testData,
        argsCode,
        testData.IsTestDataReturns(
            out ITestDataReturns? testDataReturns),
        out string testCase))
    {
        Properties.Set(PropertyNames.Description, testCase);
        TestName = GetDisplayName(testMethodName, testCase);

        if (testDataReturns != null)
        {
            ExpectedResult = testDataReturns.GetExpected();
        }
    }
}

/// <summary>
/// Represents test case data for a specific test, parameterized by a type that implements <see cref="ITestData"/>.
/// </summary>
/// <remarks>This class encapsulates the test data, argument code, and optional test method name for a test case.
/// It also determines the type arguments based on the provided <typeparamref name="TTestData"/> and the argument
/// code.</remarks>
/// <typeparam name="TTestData">The type of the test data, which must implement <see cref="ITestData"/>.</typeparam>
public sealed class TestCaseTestData<TTestData>
: TestCaseTestData
where TTestData : ITestData
{
    internal TestCaseTestData(
        TTestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    : base(
        testData,
        argsCode,
        testMethodName)
    {
        if (argsCode == ArgsCode.Properties)
        {
            Type[] genericTypes =
                typeof(TTestData).GetGenericArguments();

            TypeArgs = HasExpectedResult ?
                genericTypes[1..]
                : genericTypes;
        }
    }
}
