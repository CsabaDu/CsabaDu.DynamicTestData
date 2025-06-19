// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

public abstract class DataRowHolder<TTestData, TRow>
: IDataRowHolder<TTestData, TRow>
where TTestData : notnull, ITestData

{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified test dataRows.
    /// </summary>
    /// <param name="testData">The test dataRows to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    public DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        Add(CreateTestDataRow(
            testData,
            dataStrategy));
    }

    protected readonly List<ITestDataRow<TTestData, TRow>> dataRows = [];

    public Type TestDataType => typeof(TTestData);

    public int Count => dataRows.Count;

    public IEnumerable<TRow>? GetRows()
    => dataRows.Select(tdr => tdr.Convert());

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            IDataStrategy dataStrategy =
                GetDataStrategy(argsCode.Value);

            return dataRows.Select(
                tdr => tdr.CreateTestDataRow(
                    tdr.TestData,
                    dataStrategy)
                    .Convert());
        }

        return GetRows();
    }

    public IEnumerator<ITestDataRow> GetEnumerator()
    => dataRows.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public void Add(ITestDataRow<TTestData, TRow> testDataRow)
    => dataRows.Add(testDataRow);

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy);

    protected IDataStrategy GetDataStrategy(ArgsCode argsCode)
    {
        var row = dataRows.First();
        var dataStrategy = row.DataStrategy;

        if (argsCode == dataStrategy.ArgsCode)
        {
            return dataStrategy;
        }

        return new DataStrategy(
            argsCode,
            dataStrategy.WithExpected);
    }
}

public class DataRowHolder<TTestData>(
    TTestData testData,
    IDataStrategy dataStrategy)
: DataRowHolder<TTestData, object?[]>(
    testData,
    dataStrategy!)
where TTestData : notnull, ITestData
{
    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
   => new TestDataRow<TTestData>(
        testData,
        dataStrategy);
}