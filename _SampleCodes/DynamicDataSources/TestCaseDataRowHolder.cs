// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TestCaseDataRowHolder<TTestData>(
    TTestData testData,
    ArgsCode argsCode)
: DataRowHolder<TTestData, TestCaseData>(
    testData,
    new DataStrategy<TTestData>(argsCode, testData is ITestDataReturns))
where TTestData : notnull, ITestData
{
    public override bool? WithExpected => throw new NotImplementedException();

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);
}
