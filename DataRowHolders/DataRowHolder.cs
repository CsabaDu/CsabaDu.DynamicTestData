// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

/// <summary>
/// Abstract base class for holding test data rows with a specific data strategy
/// </summary>
/// <typeparam name="TRow">The type of the data row</typeparam>
public abstract class DataRowHolder<TRow>(IDataStrategy dataStrategy)
: IDataRowHolder<TRow>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance with the specified test data and data strategy
    /// </summary>
    /// <param name="testData">The test data to use</param>
    /// <param name="dataStrategy">The data strategy to apply</param>
    /// <exception cref="ArgumentNullException">Thrown if testData is null</exception>
    private protected DataRowHolder(
        ITestData testData,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
        testData,
        nameof(testData));

    /// <summary>
    /// Initializes a new instance from another data row holder with a new data strategy
    /// </summary>
    /// <param name="other">The other data row holder to copy from</param>
    /// <param name="dataStrategy">The new data strategy to apply</param>
    /// <exception cref="ArgumentNullException">Thrown if other is null</exception>
    private protected DataRowHolder(
        IDataRowHolder? other,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
        other,
        nameof(other));
    #endregion

    #region Properties
    /// <summary>
    /// Gets the data strategy used by this holder
    /// </summary>
    public IDataStrategy DataStrategy { get; init; } =
        GetStoredDataStrategy(
            dataStrategy?.ArgsCode,
            dataStrategy);

    ///// <summary>
    ///// Gets the type of the test data this holder works with
    ///// </summary>
    //public abstract Type TestDataType { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Retrieves the data rows with optional argument code filtering
    /// </summary>
    /// <param name="argsCode">Optional argument code to filter the data strategy</param>
    /// <returns>Enumerable of data rows or null</returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => GetRows(GetDataStrategy(argsCode));

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropertyCode? propertyCode)
    => GetRows(GetDataStrategy(
        argsCode ?? DataStrategy.ArgsCode,
        propertyCode ?? DataStrategy.PropertyCode));

    private IEnumerable<TRow>? GetRows(IDataStrategy dataStrategy)
    => GetTestDataRows()?.Select(
        tdr => (tdr as ITestDataRow<TRow>)
        !.Convert(dataStrategy));

    /// <summary>
    /// Gets the data strategy to be used for processing test data rows, potentially modified by the argsCode
    /// </summary>
    /// <param name="argsCode">Optional argument code to modify the strategy</param>
    /// <returns>The data strategy to use</returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    => GetStoredDataStrategy(argsCode, DataStrategy);

    public IDataStrategy GetDataStrategy(
        ArgsCode? argsCode,
        PropertyCode? propertyCode)
    => GetStoredDataStrategy(
        argsCode ?? DataStrategy.ArgsCode,
        propertyCode ?? DataStrategy.PropertyCode);

    #region Abstract methods
    /// <summary>
    /// Gets or creates an instance of the data row holder with the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use</param>
    /// <returns>A new data row holder instance</returns>
    public abstract IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);

    /// <summary>
    /// Retrieves all test data rows
    /// </summary>
    /// <returns>Enumerable of test data rows or null</returns>
    public abstract IEnumerable<ITestDataRow>? GetTestDataRows();
    #endregion
    #endregion
}

/// <summary>
/// Abstract base class for holding strongly-typed test data rows
/// </summary>
/// <typeparam name="TRow">The type of the data row</typeparam>
/// <typeparam name="TTestData">The type of the test data</typeparam>
public abstract class DataRowHolder<TRow, TTestData>
: DataRowHolder<TRow>, IDataRowHolder<TRow, TTestData>
where TTestData : notnull, ITestData
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance with the specified test data and data strategy
    /// </summary>
    /// <param name="testData">The test data to use</param>
    /// <param name="dataStrategy">The data strategy to apply</param>
    protected DataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
        var testDataRow =
            CreateTestDataRow(testData);

        Add(testDataRow);
    }

    /// <summary>
    /// Initializes a new instance by copying from another data row holder with a new data strategy
    /// </summary>
    /// <param name="other">The other data row holder to copy from</param>
    /// <param name="dataStrategy">The new data strategy to apply</param>
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
    #endregion

    #region Fields
    private readonly List<ITestDataRow<TRow, TTestData>> testDataRows = [];
    #endregion

    #region Properties
    ///// <summary>
    ///// Gets the type of the test data this holder works with
    ///// </summary>
    //public override sealed Type TestDataType
    //=> typeof(TTestData);

    /// <summary>
    /// Gets the number of data rows in this holder
    /// </summary>
    public int Count
    => testDataRows.Count;
    #endregion

    #region Methods
    public void Add(TTestData testData)
    {
        var testDataRow = CreateTestDataRow(testData);
        Add(testDataRow);
    }

    /// <summary>
    /// Gets the stored test data rows without any transformation
    /// </summary>
    /// <returns>
    /// The stored collection of <see cref="ITestDataRow"/> instances 
    /// or null if no rows exist
    /// </returns>
    /// <remarks>
    /// <para>
    /// This sealed override directly returns the internal collection 
    /// of test data rows exactly as they were stored.
    /// </para>
    /// <para>
    /// Unlike the base implementation, this does not apply any data strategy
    /// conversions or filtering.
    /// </para>
    /// </remarks>
    public override sealed IEnumerable<ITestDataRow>? GetTestDataRows()
    => testDataRows;

    /// <summary>
    /// Adds a test data row to this holder
    /// </summary>
    /// <param name="testDataRow">The test data row to add</param>
    public void Add(ITestDataRow<TRow, TTestData> testDataRow)
    => testDataRows.Add(testDataRow);

    /// <summary>
    /// Returns an enumerator that iterates through the collection
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection</returns>
    public IEnumerator<ITestDataRow> GetEnumerator()
    => testDataRows.GetEnumerator();

    /// <summary>
    /// Returns a non-generic enumerator that iterates through the collection
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection</returns>
    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    #region Abstract methods
    #region CreateTestDataRow
    /// <summary>
    /// Creates a new test data row from the specified test data
    /// </summary>
    /// <param name="testData">The test data to create a row from</param>
    /// <returns>A new test data row instance</returns>
    public abstract ITestDataRow<TRow, TTestData> CreateTestDataRow(
        TTestData testData);
    #endregion
    #endregion
    #endregion
}
