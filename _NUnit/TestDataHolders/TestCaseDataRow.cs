// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;
using CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;

public sealed class TestCaseDataRow<TTestData>(
    TTestData testData,
    IDataStrategy? dataStrategy)
: TestDataRow<TTestData, TestCaseData>(
    testData,
    dataStrategy),
ITestCaseDataRow
where TTestData : notnull, ITestData
{
    public TestCaseDataRow(TTestData testData,
        ArgsCode argsCode)
    :this(testData,
        new DataStrategy(
            argsCode,
            testData is ITestDataReturns))
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
        IDataStrategy dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);
}