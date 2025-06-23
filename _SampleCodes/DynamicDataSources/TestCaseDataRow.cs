// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataRows;
using CsabaDu.DynamicTestData.TestDataRows.Interfaces;
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public sealed class TestCaseDataRow<TTestData>(TTestData testData)
: TestDataRow<TTestData, TestCaseData>(testData)
where TTestData : notnull, ITestData
{
    public override TestCaseData Convert(IDataStrategy dataStrategy)
    {
        var argsCode = dataStrategy.ArgsCode;

        var isTestDataReturns = TestData is ITestDataReturns;

        var args = TestDataToParams(
            TestData,
            dataStrategy.ArgsCode,
            !isTestDataReturns,
            out string testCaseName);

        var testCaseData = new TestCaseData(args)
            .SetDescription(testCaseName);

        var testDataType = typeof(TTestData);

        if (argsCode == ArgsCode.Instance)
        {
            testCaseData.TypeArgs = [testDataType];
        }
        else
        {
            Type[] genericTypes =
                testDataType.GetGenericArguments();

            testCaseData.TypeArgs = isTestDataReturns ?
                genericTypes[1..]
                : genericTypes;
        }

        return isTestDataReturns ?
            testCaseData
                .Returns((TestData as ITestDataReturns)!
                .GetExpected())
            : testCaseData;
    }

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData)
    => new TestCaseDataRow<TTestData>(
        testData);
}