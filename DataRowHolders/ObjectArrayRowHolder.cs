// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

public class ObjectArrayRowHolder<TTestData>
: DataRowHolder<TTestData, object?[]>
where TTestData : notnull, ITestData
{
    public ObjectArrayRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(
        testData,
        dataStrategy)
    {
    }

    public ObjectArrayRowHolder(
        IDataRowHolder<TTestData, object?[]> other,
        IDataStrategy dataStrategy)
    : base(
        other,
        dataStrategy)
    {
    }

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData)
   => new ObjectArrayRow<TTestData>(
        testData);

    public override IDataRowHolder<object?[]> GetDataRowHolder(
        IDataStrategy dataStrategy)
    => dataStrategy == DataStrategy ?
        this
        : new ObjectArrayRowHolder<TTestData>(
            this,
            dataStrategy);
}