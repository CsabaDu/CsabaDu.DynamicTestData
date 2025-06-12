// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataTypes;

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
        IsTestDataReturns(
            testData,
            out ITestDataReturns? testDataReturns),
        out string testCaseName))
    {
        Properties.Set(PropertyNames.Description, testCaseName);

        if (!string.IsNullOrEmpty(testMethodName))
        {
            TestName = GetDisplayName(testMethodName, testCaseName);
        }

        if (testDataReturns != null)
        {
            ExpectedResult = testDataReturns.GetExpected();
        }
    }
    internal static bool IsTestDataReturns(ITestData testData)
    => testData is ITestDataReturns;

    private static bool IsTestDataReturns(
        ITestData testData,
        [NotNullWhen(true)] out ITestDataReturns? testDataReturns)
    {
        testDataReturns = testData as ITestDataReturns;
        return testDataReturns != null;
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
where TTestData : notnull, ITestData
{
    public TestCaseTestData(
        TTestData testData,
        ArgsCode argsCode,
        string? testMethodName)
    : base(
        testData,
        argsCode,
        testMethodName)
    {
        Type testDataType = typeof(TTestData);

        if (argsCode == ArgsCode.Properties)
        {
            Type[] genericTypes =
                testDataType.GetGenericArguments();

            TypeArgs = HasExpectedResult ?
                genericTypes[1..]
                : genericTypes;
        }
        else
        {
            TypeArgs = [testDataType];
        }
    }

    //internal TestCaseTestData(
    //    TTestData testData,
    //    IDataStrategy? dataStrategy,
    //    string? testMethodName)
    //: this(
    //    testData,
    //    dataStrategy?.ArgsCode ?? default,
    //    testMethodName)
    //{
    //}

    internal TestCaseTestData(
        TTestData testData,
        ArgsCode argsCode)
    : this(
        testData,
        argsCode,
        null)
    {
    }
}