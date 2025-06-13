// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

public abstract class DataRowHolder<TTestData, TRow>
: IDataRowHolder<TTestData, TRow>
where TTestData : notnull, ITestData

{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    public DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        WithExpected = dataStrategy.WithExpected;

        Add(CreateTestDataRow(
            testData,
            dataStrategy));
    }

    protected readonly List<ITestDataRow<TTestData, TRow>> data = [];

    public virtual bool? WithExpected { get; }

    public Type TestDataType => typeof(TTestData);

    public IEnumerable<TRow>? GetRows()
    => data.Select(tdr => tdr.Convert());

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            var dataStrategy = new DataStrategy<TTestData>(
                argsCode.Value,
                WithExpected);

            return data.Select(
                tdr => tdr.CreateTestDataRow(
                    tdr.TestData,
                    dataStrategy)
                .Convert());
        }

        return GetRows();
    }

    public IEnumerator<ITestDataRow> GetEnumerator()
    => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public IEnumerable<ITestDataRow<TRow>> GetTestDataRows()
    => data;

    public void Add(ITestDataRow<TTestData, TRow> testDataRow)
    => data.Add(testDataRow);

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy);
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