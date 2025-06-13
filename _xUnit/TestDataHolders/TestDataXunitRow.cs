// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TestDataHolders;

public sealed class TestDataXunitRow<TTestData>(
    TTestData testData,
    IDataStrategy dataStrategy)
: TestDataRow<TTestData, object?[]>(
    testData,
    dataStrategy),
ITestDataXunitRow
where TTestData : notnull, ITestData
{
    public override object?[] Convert()
    => Params;

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
    => new TestDataXunitRow<TTestData>(
        testData,
        dataStrategy);
}