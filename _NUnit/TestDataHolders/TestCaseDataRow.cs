// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;

public sealed class TestCaseDataRow<TTestData>(
    TTestData testData,
    ArgsCode argsCode)
: TestDataRow<TTestData, TestCaseData>(
    testData,
    new DataStrategy(
        argsCode,
        IsTestDataReturns(testData))),
ITestCaseDataRow
where TTestData : notnull, ITestData
{
    public TestCaseDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    : this(
        testData,
        dataStrategy?.ArgsCode ?? default)
    {
    }

    public override TestCaseData Convert()
    => new TestCaseTestData<TTestData>(
        TestData,
        DataStrategy);

    public TestCaseData Convert(string? testMethodName)
    => new TestCaseTestData<TTestData>(
        TestData,
        DataStrategy,
        testMethodName);

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);
}