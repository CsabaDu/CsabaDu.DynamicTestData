// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)


namespace CsabaDu.DynamicTestData.xUnit.TestDataHolders;

public sealed class DataXunitRowHolder<TTestData>(
    TTestData testData,
    ArgsCode argsCode)
: DataRowHolder<TTestData, object?[]>(
    testData,
    new DataStrategy(
        argsCode,
        IsExpected(testData))),
IDataXunitRowHolder
where TTestData : notnull, ITestData
{
    public DataXunitRowHolder(
        TTestData testData,
        IDataStrategy? dataStrategy)
    : this(
        testData,
        dataStrategy?.ArgsCode ?? default)
    {
    }

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestDataXunitRow<TTestData>(
        testData,
        dataStrategy);
}
