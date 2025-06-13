// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;

public class TestCaseDataRow<TTestData>(
    TTestData testData,
    IDataStrategy dataStrategy)
: TestDataRow<TTestData, TestCaseData>(
    testData,
    dataStrategy),
ITestCaseDataRow
where TTestData : notnull, ITestData
{
    public TestCaseData Convert(string? testMethodName)
    => new TestCaseTestData<TTestData>(
        TestData,
        DataStrategy.ArgsCode,
        testMethodName);

    public override TestCaseData Convert()
    => Convert(null);

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);
}