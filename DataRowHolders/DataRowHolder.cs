// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

public abstract class DataRowHolder<TRow>(IDataStrategy dataStrategy)
: IDataRowHolder<TRow>
{
    private protected DataRowHolder(
        ITestData testData,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
            testData,
            nameof(testData));

    private protected DataRowHolder(
        IDataRowHolder? other,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
            other,
            nameof(other));

    public IDataStrategy DataStrategy { get; init; } = dataStrategy
        ?? throw new ArgumentNullException(nameof(dataStrategy));

    public abstract Type TestDataType { get; }

    public IEnumerable<TRow>? GetRows()
    => (GetDataRowHolder(DataStrategy) as IEnumerable<ITestDataRow>)
        ?.Select(tdr => (tdr as ITestDataRow<TRow>)
        !.Convert(DataStrategy));

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => argsCode.HasValue ?
        GetDataRowHolder(GetDataStrategy(argsCode.Value))
        .GetRows()
        : GetRows();

    public abstract IDataRowHolder<TRow> GetDataRowHolder(
        IDataStrategy dataStrategy);

    protected IDataStrategy GetDataStrategy(ArgsCode argsCode)
    => argsCode == DataStrategy.ArgsCode ?
        DataStrategy
        : new DataStrategy(
            argsCode,
            DataStrategy.WithExpected);
}

public abstract class DataRowHolder<TTestData, TRow>
: DataRowHolder<TRow>, IDataRowHolder<TTestData, TRow>
where TTestData : notnull, ITestData

{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectArrayRow{TTestData}"/> class with the specified test dataRows.
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
