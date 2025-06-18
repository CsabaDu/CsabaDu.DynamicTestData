// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.TestDataHolders;

namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicTestCaseDataSource(ArgsCode argsCode)
: DynamicNamedDataSource<TestCaseData>(argsCode, typeof(ITestDataReturns)),
INamedRows<TestCaseData>
{
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
}

public abstract class DynamicNunitDataSource(ArgsCode argsCode)
: DynamicDataSource(argsCode, typeof(ITestDataReturns));
