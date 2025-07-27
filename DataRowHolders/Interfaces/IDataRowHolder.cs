// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a container that holds test data rows along with their associated <see cref="IDataStrategy"/>.
/// Extends <see cref="ITestDataRows"/> to provide direct access to the data strategy.
/// </summary>
/// <remarks>
/// This interface is typically implemented by test data sources that need to maintain
/// both the test cases and the strategy for processing them. The data strategy
/// determines how test arguments are formatted and how expected results are handled.
/// </remarks>
public interface IDataRowHolder
: ITestDataRows
{
    /// <summary>
    /// Gets the data strategy associated with the test data rows.
    /// </summary>
    /// <value>
    /// An <see cref="IDataStrategy"/> instance that defines how the contained
    /// test data should be processed and formatted.
    /// </value>
    /// <remarks>
    /// The strategy should be consistent with all test data rows returned by
    /// <see cref="ITestDataRows.GetTestDataRows"/>. Implementations should ensure
    /// the strategy is never null.
    /// </remarks>
    IDataStrategy DataStrategy { get; }
}

/// <summary>
/// Represents a strongly-typed container for test data rows that combines row access,
/// data strategy management, and type information. Extends the non-generic <see cref="IDataRowHolder"/>
/// with type-specific operations.
/// </summary>
/// <typeparam name="TRow">The type of data rows contained in this holder.</typeparam>
/// <remarks>
/// <para>
/// This interface combines three key test data capabilities:
/// <list type="bullet">
///   <item>Row storage and access (via <see cref="IRows{TRow}"/>)</item>
///   <item>Data processing strategy (via <see cref="IDataRowHolder"/>)</item>
///   <item>Type information (via <see cref="ITestDataType"/>)</item>
/// </list>
/// </para>
/// <para>
/// Useful when test infrastructure needs to maintain both the test data and its processing rules
/// while being aware of the concrete row type.
/// </para>
/// </remarks>
public interface IDataRowHolder<TRow>
: IDataRowHolder,
ITestDataType,
IRows<TRow>
{
    /// <summary>
    /// Gets or creates a new instance of the data row holder with the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use in the new holder instance.</param>
    /// <returns>
    /// A new <see cref="IDataRowHolder{TRow}"/> instance configured with the specified strategy.
    /// </returns>
    /// <remarks>
    /// <para>
    /// Implementations should ensure the returned holder maintains all existing test data
    /// while applying the new processing strategy.
    /// </para>
    /// <para>
    /// This method enables creating variations of the same test data with different processing rules.
    /// </para>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dataStrategy"/> is null.
    /// </exception>
    /// </remarks>
    IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);
}

/// <summary>
/// Represents a strongly-typed container for test data rows that combines collection functionality,
/// row access, and test data row creation capabilities.
/// </summary>
/// <typeparam name="TRow">The type of data rows contained in this holder.</typeparam>
/// <typeparam name="TTestData">The type of test data associated with each row, which must be non-null and implement <see cref="ITestData"/>.</typeparam>
/// <remarks>
/// <para>
/// This interface combines multiple test data capabilities:
/// <list type="bullet">
///   <item>Collection functionality (via <see cref="IReadOnlyCollection{ITestDataRow}"/>)</item>
///   <item>Data strategy management (via <see cref="IDataRowHolder{TRow}"/>)</item>
///   <item>Test data row creation (via <see cref="ITestDataRowFactory{TRow, TTestData}"/>)</item>
/// </list>
/// </para>
/// <para>
/// Useful when test infrastructure needs to manage a collection of test cases while maintaining
/// type safety and providing creation capabilities.
/// </para>
/// </remarks>
public interface IDataRowHolder<TRow, TTestData>
: IReadOnlyCollection<ITestDataRow>,
IDataRowHolder<TRow>,
ITestDataRowFactory<TRow, TTestData>,
IAddTestData<TTestData>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Adds a new strongly-typed test data row to the collection.
    /// </summary>
    /// <param name="testDataRow">The test data row to add to the collection.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="testDataRow"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="testDataRow"/> is incompatible with the holder's type constraints.</exception>
    /// <remarks>
    /// Implementations should ensure the added row maintains consistency with the holder's
    /// data strategy and type constraints.
    /// </remarks>
    void Add(ITestDataRow<TRow, TTestData> testDataRow);
}
