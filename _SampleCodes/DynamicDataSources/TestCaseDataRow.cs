// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public sealed class TestCaseDataRow<TTestData>(TTestData testData, IDataStrategy? dataStrategy)
: TestDataRow<TTestData, TestCaseData>(testData, dataStrategy)
where TTestData : notnull, ITestData
{
    public override TestCaseData Convert()
    {
        var argsCode = DataStrategy.ArgsCode;

        var isTestDataReturns = TestData is ITestDataReturns;

        var args = TestDataToParams(
            TestData,
            DataStrategy.ArgsCode,
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
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);
}