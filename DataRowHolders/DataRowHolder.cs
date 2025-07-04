// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

public abstract class DataRowHolder<TRow>(IDataStrategy dataStrategy)
: IDataRowHolder<TRow>
{
    #region Constructors
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
    #endregion

    public IDataStrategy DataStrategy { get; init; } = dataStrategy
        ?? throw new ArgumentNullException(nameof(dataStrategy));

    public abstract Type TestDataType { get; }

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    {
        var testDataRows = GetTestDataRows();
        var dataStrategy = GetDataStrategy(argsCode);

        return testDataRows?.Select(
            tdr => (tdr as ITestDataRow<TRow>)
            !.Convert(dataStrategy));
    }

    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    {
        argsCode ??= DataStrategy.ArgsCode;

        return argsCode == DataStrategy.ArgsCode ?
            DataStrategy
            : new DataStrategy(
                argsCode.Value,
                DataStrategy.WithExpected);
    }
    
    public abstract IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);
    public abstract IEnumerable<ITestDataRow>? GetTestDataRows();
}

public abstract class DataRowHolder<TRow, TTestData>
: DataRowHolder<TRow>, IDataRowHolder<TRow, TTestData>
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
        IDataRowHolder<TRow, TTestData> other,
        IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
        foreach (var dataRow in other)
        {
            var testDataRow =
                dataRow as ITestDataRow<TRow, TTestData>;

            Add(testDataRow!);
        }
    }

    private readonly List<ITestDataRow<TRow, TTestData>> dataRows = [];

    public override sealed Type TestDataType
    => typeof(TTestData);

    public int Count
    => dataRows.Count;

    public override sealed IEnumerable<ITestDataRow>? GetTestDataRows()
    {
        var dataStrategy = GetDataStrategy(ArgsCode.Instance);

        return GetDataRowHolder(dataStrategy)
            as IEnumerable<ITestDataRow>;
    }

    public IEnumerator<ITestDataRow> GetEnumerator()
    => dataRows.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public void Add(ITestDataRow<TRow, TTestData> testDataRow)
    => dataRows.Add(testDataRow);

    public abstract ITestDataRow<TRow, TTestData> CreateTestDataRow(
        TTestData testData);
}
