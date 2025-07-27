// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicDataRowSource<TDataRowHolder, TRow>(ArgsCode argsCode, PropertyCode propertyCode)
: DynamicDataSource<TDataRowHolder>(argsCode, propertyCode),
ITestDataRows,
IRows<TRow>
where TDataRowHolder : class, IDataRowHolder<TRow>
{
    #region Public Methods
    #region GetTestDataRows
    /// <summary>
    /// Retrieves all stored test data rows.
    /// </summary>
    /// <returns>
    /// Enumerable of test data rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<ITestDataRow>? GetTestDataRows()
    => DataHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    /// <summary>
    /// Gets converted test rows using the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">Optional ArgsCode override for conversion.</param>
    /// <returns>
    /// Enumerable of converted rows, or null if no rows exist.
    /// </returns>
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataHolder?.GetRows(argsCode);

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropertyCode? propertyCode)
    => DataHolder?.GetRows(argsCode, propertyCode);
    #endregion

    #region GetDataStrategy
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    => GetStoredDataStrategy(argsCode, this);

    public IDataStrategy GetDataStrategy(
        ArgsCode? argsCode,
        PropertyCode? propertyCode)
    => GetStoredDataStrategy(
        argsCode ?? ArgsCode,
        propertyCode ?? PropertyCode);
    #endregion
    #endregion

    #region Add
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
/// Generic base class for dynamic test data sources with typed rows.
/// </summary>
/// <typeparam name="TRow">The data row type.</typeparam>
/// <param name="argsCode">Default argument conversion code.</param>
/// <param name="expectedResultType">Optional expected result type for validation.</param>
/// <remarks>
/// <para>Manages collections of typed test data rows with conversion strategies.</para>
/// <para>Provides methods for adding test cases with various argument combinations.</para>
/// </remarks>
public abstract class DynamicDataRowSource<TRow>(ArgsCode argsCode, PropertyCode propertyCode)
: DynamicDataRowSource<IDataRowHolder<TRow>, TRow>(argsCode, propertyCode);
