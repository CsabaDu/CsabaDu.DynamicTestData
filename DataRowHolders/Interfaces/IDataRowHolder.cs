// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Holds test data with its processing strategy.
/// </summary>
/// <remarks>
/// Combines test cases with their execution configuration.
/// </remarks>
public interface IDataRowHolder : ITestDataRows
{
    /// <summary>
    /// Gets the configured processing strategy.
    /// </summary>
    /// <value>
    /// Current data transformation rules (never null).
    /// </value>
    IDataStrategy DataStrategy { get; }
}

/// <summary>
/// Typed container for test data with strategy management.
/// </summary>
/// <typeparam name="TRow">The target row type.</typeparam>
public interface IDataRowHolder<TRow> : IDataRowHolder, IRows<TRow>
{
    /// <summary>
    /// Creates a variant with different processing rules.
    /// </summary>
    /// <param name="dataStrategy">
    /// New processing rules (cannot be null).
    /// </param>
    /// <returns>
    /// New holder with original data but new strategy.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if strategy is null.
    /// </exception>
    IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);
}

/// <summary>
/// Typed container with collection support.
/// </summary>
/// <typeparam name="TRow">Row type.</typeparam>
/// <typeparam name="TTestData">Test data type (non-nullable ITestData).</typeparam>
public interface IDataRowHolder<TRow, TTestData>
    : IReadOnlyCollection<ITestDataRow>,
      IDataRowHolder<TRow>,
      ITestDataRowFactory<TRow, TTestData>,
      IAddTestData<TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Adds a typed test case.
    /// </summary>
    /// <param name="testDataRow">
    /// Case to add (cannot be null).
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if row is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if row is incompatible.
    /// </exception>
    void Add(ITestDataRow<TRow, TTestData> testDataRow);
}