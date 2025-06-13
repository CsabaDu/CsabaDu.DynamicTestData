// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DynamicDataSources;
using CsabaDu.DynamicTestData.xUnit.TestDataHolders;

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTestDataXunitSource(ArgsCode argsCode)
: DynamicDataSource<object?[]>(argsCode, nameof(IExpected))
{
    protected override ITestDataRow<TTestData, object?[]> CreateTestDataRow<TTestData>(
        TTestData testData)
    => new TestDataXunitRow<TTestData>(
        testData,
        this);

    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    => DataRowHolder = new DataRowHolder<TTestData>(
        testData,
        this);
}
