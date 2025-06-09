// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using System.Collections;

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
        IDataStrategy dataStrategy,
        TTestData testData)
    {
        Add(CreateTestDataRow(
        dataStrategy
            ?? throw new ArgumentNullException(
                nameof(dataStrategy)),
        testData));

        _withExpected = dataStrategy.WithExpected;
    }

    protected readonly List<ITestDataRow<TTestData, TRow>> data = [];
    private readonly bool? _withExpected;

    private sealed record DataStrategy(
        ArgsCode ArgsCode,
        bool? WithExpected)
    : IDataStrategy;

    public IEnumerable<TRow>? GetRows()
    => data.Select(tdr => tdr.Convert());

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            var dataStrategy = new DataStrategy(
                argsCode.Value,
                _withExpected);

            return data.Select(
                tdr => tdr.CreateTestDataRow(
                    dataStrategy,
                    tdr.GetTestData())
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
        IDataStrategy dataStrategy,
        TTestData testData);
}

public sealed class DataRowHolder<TTestData>(
    IDataStrategy dataStrategy,
    TTestData testData)
: DataRowHolder<TTestData, object?[]>(
    dataStrategy,
    testData)
where TTestData : notnull, ITestData
{
    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        IDataStrategy dataStrategy,
        TTestData testData)
    => new TestDataRow<TTestData>(
        dataStrategy,
        testData);
}