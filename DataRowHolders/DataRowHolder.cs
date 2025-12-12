// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DataRowHolders.Interfaces;
using CsabaDu.DynamicTestData.TestDataRows.Interfaces;
using static CsabaDu.DynamicTestData.DataStrategyTypes.DataStrategy;

namespace CsabaDu.DynamicTestData.DataRowHolders;

/// <summary>
/// Abstract base class for managing test data rows with a specific processing strategy.
/// </summary>
/// <typeparam name="TRow">The target type for converted test data rows.</typeparam>
/// <remarks>
/// Provides core functionality for:
/// <list type="bullet">
///   <item>Data strategy management</item>
///   <item>Row conversion and retrieval</item>
///   <item>Strategy-based filtering</item>
/// </list>
/// </remarks>
public abstract class DataRowHolder<TRow>(IDataStrategy dataStrategy)
: IDataRowHolder<TRow>
{
    #region Properties
    /// <summary>
    /// Gets the configured data processing strategy.
    /// </summary>
    /// <value>
    /// The strategy determining how test data is formatted and processed.
    /// </value>
    public IDataStrategy DataStrategy { get; init; } = GetStoredDataStrategy(dataStrategy);
    #endregion

    #region Methods
    /// <summary>
    /// Retrieves data rows, optionally converted by <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">Optional strategy modifier.</param>
    /// <returns>
    /// Converted data rows or null if none available.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => GetRows(GetDataStrategy(argsCode));

    /// <summary>
    /// Retrieves data rows, optionally converted by <see cref="ArgsCode"/> and <see cref="PropsCode"/>.
    /// </summary>
    /// <param name="argsCode">Strategy modifier.</param>
    /// <param name="propsCode">Property inclusion modifier.</param>
    /// <returns>
    /// Converted data rows or null if none available.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropsCode? propsCode)
    => GetRows(GetDataStrategy(argsCode, propsCode));

    private IEnumerable<TRow>? GetRows(IDataStrategy dataStrategy)
    => GetTestDataRows()?.Select(
        tdr => (tdr as ITestDataRow<TRow>)
        !.Convert(dataStrategy));

    /// <summary>
    /// Gets the processing strategy, optionally modified by <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">Optional strategy modifier.</param>
    /// <returns>
    /// The configured data processing strategy.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    => GetStoredDataStrategy(argsCode, DataStrategy);

    /// <summary>
    /// Gets the processing strategy with property control.
    /// </summary>
    /// <param name="argsCode">Strategy modifier.</param>
    /// <param name="propsCode">Property inclusion modifier.</param>
    /// <returns>
    /// The configured data processing strategy.
    /// </returns>
    public IDataStrategy GetDataStrategy(
        ArgsCode? argsCode,
        PropsCode? propsCode)
    => GetStoredDataStrategy(
        argsCode ?? DataStrategy.ArgsCode,
        propsCode ?? DataStrategy.PropsCode);
    #endregion

    #region Abstract methods
    /// <summary>
    /// Gets this instance, or creates a new one with the specified strategy.
    /// </summary>
    /// <param name="dataStrategy">The processing strategy to use.</param>
    /// <returns>
    /// The recent or a new holder instance with the same data but new strategy.
    /// </returns>
    public abstract IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);

    /// <summary>
    /// Gets an enumerable collection of all managed <see cref="ITestDataRow"/> instances.
    /// </summary>
    /// <returns>
    /// The collection of <see cref="ITestDataRow"/> instances or null if none available.
    /// </returns>
    public abstract IEnumerable<ITestDataRow>? GetTestDataRows();
    #endregion
}

/// <summary>
/// Abstract base class for managing strongly-typed test data rows.
/// </summary>
/// <typeparam name="TRow">The target row conversion type.</typeparam>
/// <typeparam name="TTestData">The test data type (must implement ITestData and be non-nullable).</typeparam>
/// <remarks>
/// Extends <see cref="DataRowHolder{TRow}"/> with:
/// <list type="bullet">
///   <item>Strongly-typed test data storage</item>
///   <item>Collection management</item>
///   <item>Row creation capabilities</item>
/// </list>
/// </remarks>
public abstract class DataRowHolder<TRow, TTestData>
: DataRowHolder<TRow>,
IDataRowHolder<TRow, TTestData>
where TTestData : notnull, ITestData
{
    #region Fields
    private readonly List<ITestDataRow<TRow, TTestData>> testDataRows = [];
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance with test data and processing strategy.
    /// </summary>
    /// <param name="testData">The test data to manage.</param>
    /// <param name="dataStrategy">The processing strategy to apply.</param>
    protected DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(dataStrategy)
    {
        Add(testData);
    }

    /// <summary>
    /// Initializes a new instance by copying from another holder with a new strategy.
    /// </summary>
    /// <param name="other">The source data holder.</param>
    /// <param name="dataStrategy">The new processing strategy.</param>
    protected DataRowHolder(
        IDataRowHolder<TRow, TTestData> other,
        IDataStrategy dataStrategy)
    : base(dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(other, nameof(other));

        foreach (var tdr in other)
        {
            var testDataRow = tdr as ITestDataRow<TRow, TTestData>;
            Add(testDataRow!);
        }
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the number of test data rows in the <see cref="IReadOnlyCollection{ITestDataRow}"/> collection.
    /// </summary>
    public int Count => testDataRows.Count;
    #endregion

    #region Methods
    /// <summary>
    /// Adds a new strongly-typed <see cref="ITestData"/> to the collection by creating and storing a new row.
    /// </summary>
    /// <param name="testData">The test data to add.</param>
    public void Add(TTestData testData)
    {
        if (testData.ContainedBy(testDataRows))
        {
            return;
        }

        var testDataRow = CreateTestDataRow(testData);
        Add(testDataRow);
    }

    public void AddRange(IEnumerable<TTestData> testDataCollection)
    {
        ArgumentNullException.ThrowIfNull(
            testDataCollection,
            nameof(testDataCollection));

        foreach (var testData in testDataCollection)
        {
            Add(testData);
        }
    }

    public IEnumerable<TTestData> GetTestDataCollection()
    => testDataRows.Select(x => x.TestData);

    /// <summary>
    /// Gets the stored collection of <see cref="ITestDataRow"/> instances without any transormation.
    /// </summary>
    /// <returns>
    /// The collection of strongly-typed test data rows.
    /// </returns>
    public override sealed IEnumerable<ITestDataRow>? GetTestDataRows()
    => testDataRows;

    /// <summary>
    /// Adds a pre-created test data row to the collection.
    /// </summary>
    /// <param name="testDataRow">The row to add.</param>
    public void Add(ITestDataRow<TRow, TTestData> testDataRow)
    => testDataRows.Add(testDataRow);

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the test data rows.</returns>
    public IEnumerator<ITestDataRow> GetEnumerator()
    => testDataRows.GetEnumerator();

    /// <summary>
    /// Returns a non-generic enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the test data rows.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();
    #endregion

    #region Abstract methods
    /// <summary>
    /// Creates a new test data row from the specified test data.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <returns>
    /// A new strongly-typed test data row instance.
    /// </returns>
    public abstract ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData testData);
    #endregion
}