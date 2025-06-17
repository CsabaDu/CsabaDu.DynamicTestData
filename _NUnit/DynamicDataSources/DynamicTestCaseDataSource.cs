// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestDataHolders;

namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicTestCaseDataSource(ArgsCode argsCode)
: DynamicDataSource<TestCaseData>(argsCode, typeof(ITestDataReturns)),
INamedRows<TestCaseData>
{
    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName)
    => GetTestCaseDataRowHolder()?
        .GetNamedRows(
            testMethodName);

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName,
        ArgsCode? argsCode)
    => GetTestCaseDataRowHolder()?
        .GetNamedRows(
            testMethodName,
            argsCode);

    protected override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow<TTestData>(
        TTestData testData)
    => new TestCaseDataRow<TTestData>(
        testData,
        this);

    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    => DataRowHolder = new TestCaseDataRowHolder<TTestData>(
        testData,
        this);

    protected ITestCaseDataRowHolder? GetTestCaseDataRowHolder()
    => DataRowHolder as ITestCaseDataRowHolder;
}
