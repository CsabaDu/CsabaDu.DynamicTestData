// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TestDataHolders;

public sealed class DataXunitRowHolder<TTestData>(
    TTestData testData,
    IDataStrategy dataStrategy)
: DataRowHolder<TTestData, object?[]>(
    testData,
    dataStrategy),
IDataXunitRowHolder
where TTestData : notnull, ITestData
{
    public override bool? WithExpected { get; } =
        DataStrategy<TTestData>.GetWithExpected(
            typeof(IExpected));

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
    => new TestDataXunitRow<TTestData>(
        testData,
        dataStrategy);
}
