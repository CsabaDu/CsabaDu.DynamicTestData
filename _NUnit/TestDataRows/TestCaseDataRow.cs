// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)



namespace CsabaDu.DynamicTestData.NUnit.TestDataRows;

public class TestCaseDataRow<TTestData>(
    TTestData testData)
: TestDataRow<TTestData, TestCaseTestData>(
    testData),
INamedTestDataRow<TestCaseTestData>

where TTestData : notnull, ITestData
{
    public TestCaseTestData Convert(IDataStrategy dataStrategy, string? testMethodName)
    => new TestCaseTestData<TTestData>(
        TestData,
        dataStrategy.ArgsCode,
        testMethodName);

    public override TestCaseTestData Convert(IDataStrategy dataStrategy)
    => Convert(dataStrategy, null);

    public override ITestDataRow<TTestData, TestCaseTestData> CreateTestDataRow(
        TTestData testData)
    => new TestCaseDataRow<TTestData>(
        testData);
}