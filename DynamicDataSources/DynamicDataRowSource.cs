// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Abstract base class for dynamic test data sources that manage strongly-typed data rows.
/// </summary>
/// <typeparam name="TDataRowHolder">The type of data holder (must implement <see cref="IDataRowHolder{TRow}"/>).</typeparam>
/// <typeparam name="TRow">The type of data rows produced by this source.</typeparam>
/// <param name="argsCode">The default argument processing strategy.</param>
/// <param name="propertyCode">The default property inclusion strategy.</param>
/// <remarks>
/// <para>
/// Combines functionality from:
/// <list type="bullet">
///   <item><see cref="DynamicDataSource{TDataHolder}"/> for base data management</item>
///   <item><see cref="ITestDataRows"/> for test row enumeration</item>
///   <item><see cref="IRows{TRow}"/> for typed row access</item>
/// </list>
/// </para>
/// <para>
/// Key features:
/// <list type="bullet">
///   <item>Type-safe row conversion and retrieval</item>
///   <item>Configurable argument processing</item>
///   <item>Duplicate test case prevention</item>
///   <item>Automatic holder initialization</item>
/// </list>
/// </para>
/// </remarks>
public abstract class DynamicDataRowSource<TDataRowHolder, TRow>(ArgsCode argsCode, PropertyCode propertyCode)
    : DynamicDataSource<TDataRowHolder>(argsCode, propertyCode),
      ITestDataRows,
      IRows<TRow>
    where TDataRowHolder : class, IDataRowHolder<TRow>
{
    #region Public Methods
    #region GetTestDataRows
    /// <summary>
    /// Retrieves all managed test data rows.
    /// </summary>
    /// <returns>
    /// The complete collection of test data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<ITestDataRow>? GetTestDataRows()
        => DataHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    /// <summary>
    /// Retrieves converted data rows with optional strategy override.
    /// </summary>
    /// <param name="argsCode">Optional argument processing override.</param>
    /// <returns>
    /// The converted data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
        => DataHolder?.GetRows(argsCode);

    /// <summary>
    /// Retrieves converted data rows with strategy and property overrides.
    /// </summary>
    /// <param name="argsCode">Argument processing override.</param>
    /// <param name="propertyCode">Property inclusion override.</param>
    /// <returns>
    /// The converted data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropertyCode? propertyCode)
        => DataHolder?.GetRows(argsCode, propertyCode);
    #endregion

    #region GetDataStrategy
    /// <summary>
    /// Gets the data strategy with optional argument code override.
    /// </summary>
    /// <param name="argsCode">Optional argument processing override.</param>
    /// <returns>
    /// The configured data strategy instance.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
        => GetStoredDataStrategy(argsCode, this);

    /// <summary>
    /// Gets the data strategy with argument and property overrides.
    /// </summary>
    /// <param name="argsCode">Argument processing override.</param>
    /// <param name="propertyCode">Property inclusion override.</param>
    /// <returns>
    /// The configured data strategy instance.
    /// </returns>
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode, PropertyCode? propertyCode)
        => GetStoredDataStrategy(argsCode ?? ArgsCode, propertyCode ?? PropertyCode);
    #endregion
    #endregion

    #region Add
    /// <summary>
    /// Adds test data to the holder, initializing if necessary and preventing duplicates.
    /// </summary>
    /// <typeparam name="TTestData">The test data type (must implement <see cref="ITestData"/>).</typeparam>
    /// <param name="testData">The test data to add.</param>
    protected override void Add<TTestData>(TTestData testData)
    {
        if (DataHolder is not IDataRowHolder<TRow, TTestData> dataRowHolder)
        {
            InitDataHolder(testData);
            return;
        }

        if (dataRowHolder.Any(testData.Equals))
        {
            return;
        }

        dataRowHolder.Add(testData);
    }
    #endregion
}

/// <summary>
/// Abstract base class for dynamic test data sources with simplified row holder management.
/// </summary>
/// <typeparam name="TRow">The type of data rows produced by this source.</typeparam>
/// <param name="argsCode">The default argument processing strategy.</param>
/// <param name="propertyCode">The default property inclusion strategy.</param>
/// <remarks>
/// <para>
/// Specializes <see cref="DynamicDataRowSource{TDataRowHolder, TRow}"/> using <see cref="IDataRowHolder{TRow}"/>
/// as the default holder type, simplifying common use cases.
/// </para>
/// <para>
/// Inherits all functionality from the base class while providing a more focused interface
/// for standard test data scenarios.
/// </para>
/// </remarks>
public abstract class DynamicDataRowSource<TRow>(ArgsCode argsCode, PropertyCode propertyCode)
    : DynamicDataRowSource<IDataRowHolder<TRow>, TRow>(argsCode, propertyCode);