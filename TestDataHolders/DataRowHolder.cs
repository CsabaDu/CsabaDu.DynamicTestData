// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders;

public abstract class DataRowHolder<TTestData, TRow>
: DataRowHolderBase<TRow>, IDataRowHolder<TTestData, TRow>
where TTestData : notnull, ITestData

{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified test dataRows.
    /// </summary>
    /// <param name="testData">The test dataRows to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    protected DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
        var testDataRow =
            CreateTestDataRow(testData);

        Add(testDataRow);
    }

    protected DataRowHolder(
        IDataRowHolder<TTestData, TRow> other,
        IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
        foreach (var dataRow in other)
        {
            var testDataRow =
                dataRow as ITestDataRow<TTestData, TRow>;

            Add(testDataRow!);
        }
    }

    protected readonly List<ITestDataRow<TTestData, TRow>> dataRows = [];

    public override Type TestDataType => typeof(TTestData);
    public int Count => dataRows.Count;

    public IEnumerator<ITestDataRow> GetEnumerator()
    => dataRows.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public void Add(ITestDataRow<TTestData, TRow> testDataRow)
    => dataRows.Add(testDataRow);

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData);
}

public class DataRowHolder<TTestData>
: DataRowHolder<TTestData, object?[]>
where TTestData : notnull, ITestData
{
    public DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(
        testData,
        dataStrategy)
    {
    }

    public DataRowHolder(
        IDataRowHolder<TTestData, object?[]> other,
        IDataStrategy dataStrategy)
    : base(
        other,
        dataStrategy)
    {
    }

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData)
   => new TestDataRow<TTestData>(
        testData);

    public override IDataRowHolder<object?[]> GetDataRowHolder(
        IDataStrategy dataStrategy)
    => new DataRowHolder<TTestData>(
        this,
        dataStrategy);
}