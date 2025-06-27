// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicObjectArraySource(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<object?[]>(argsCode, expectedResultType)
{
    protected override ITestDataRow<object?[], TTestData> CreateTestDataRow<TTestData>(
        TTestData testData)
    => new ObjectArrayRow<TTestData>(
        testData);

    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    => DataRowHolder = new ObjectArrayRowHolder<TTestData>(
        testData,
        this);
}
