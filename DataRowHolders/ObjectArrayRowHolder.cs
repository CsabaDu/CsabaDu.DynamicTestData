// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

public class ObjectArrayRowHolder<TTestData>
: DataRowHolder<object?[], TTestData>
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
        IDataRowHolder<object?[], TTestData> other,
        IDataStrategy dataStrategy)
    : base(
        other,
        dataStrategy)
    {
    }

    public override ITestDataRow<object?[], TTestData> CreateTestDataRow(
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