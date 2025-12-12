// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.DataRowHolders.Interfaces;
using CsabaDu.DynamicTestData.TestDataRows.Interfaces;

namespace CsabaDu.DynamicTestData.DataRowHolders;

/// <summary>
/// Abstract base class for managing named test data rows with strongly-typed test data.
/// </summary>
/// <typeparam name="TRow">The target type for converted test data rows.</typeparam>
/// <typeparam name="TTestData">The test data type (must implement <see cref="ITestData"/> and be non-nullable).</typeparam>
/// <remarks>
/// <para>
/// Combines functionality from:
/// <list type="bullet">
///   <item><see cref="DataRowHolder{TRow, TTestData}"/> for typed data management</item>
///   <item><see cref="INamedDataRowHolder{TRow}"/> for named test case support</item>
/// </list>
/// </para>
/// <para>
/// Provides named test case retrieval while maintaining strong typing for both test data and converted rows.
/// </para>
/// </remarks>
public abstract class NamedDataRowHolder<TRow, TTestData>
: DataRowHolder<TRow, TTestData>,
INamedDataRowHolder<TRow>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Initializes a new instance with test data and processing strategy.
    /// </summary>
    /// <param name="testData">The test data to manage.</param>
    /// <param name="dataStrategy">The processing strategy to apply.</param>
    protected NamedDataRowHolder(TTestData testData, IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
    }

    /// <summary>
    /// Initializes a new instance by copying from another holder with a new strategy.
    /// </summary>
    /// <param name="other">The source data holder.</param>
    /// <param name="dataStrategy">The new processing strategy.</param>
    protected NamedDataRowHolder(IDataRowHolder<TRow, TTestData> other, IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
    }

    /// <summary>
    /// Retrieves named test cases from a data holder with optional strategy customization.
    /// </summary>
    /// <param name="dataHolder">The source of test data rows (cannot be null).</param>
    /// <param name="testMethodName">The associated test method name (optional).</param>
    /// <param name="dataStrategy">The processing strategy to use (defaults to holder's strategy if null).</param>
    /// <returns>
    /// Converted test cases with naming context or null if no cases available.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when dataHolder is null.</exception>
    public static IEnumerable<TRow>? GetRows(
        [NotNull] INamedDataRowHolder<TRow> dataHolder,
        string? testMethodName,
        IDataStrategy? dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataHolder, nameof(dataHolder));

        var testDataRows = dataHolder.GetTestDataRows();
        dataStrategy ??= dataHolder.DataStrategy;

        return testDataRows?.Select(
            tdr => (tdr as INamedTestDataRow<TRow>)!.Convert(dataStrategy, testMethodName));
    }

    /// <summary>
    /// Retrieves named test cases with optional strategy modification.
    /// </summary>
    /// <param name="testMethodName">The associated test method name (optional).</param>
    /// <param name="argsCode">Optional strategy modifier.</param>
    /// <returns>
    /// Converted test cases with naming context or null if no cases available.
    /// </returns>
    public IEnumerable<TRow>? GetRows(
        string? testMethodName,
        ArgsCode? argsCode)
        => GetRows(this, testMethodName, GetDataStrategy(argsCode));

    /// <summary>
    /// Retrieves named test cases with strategy and property modification.
    /// </summary>
    /// <param name="testMethodName">The associated test method name (optional).</param>
    /// <param name="argsCode">Strategy modifier.</param>
    /// <param name="propsCode">Property inclusion modifier.</param>
    /// <returns>
    /// Converted test cases with naming context or null if no cases available.
    /// </returns>
    public IEnumerable<TRow>? GetRows(
        string? testMethodName,
        ArgsCode? argsCode,
        PropsCode? propsCode)
        => GetRows(this, testMethodName, GetDataStrategy(argsCode, propsCode));
}