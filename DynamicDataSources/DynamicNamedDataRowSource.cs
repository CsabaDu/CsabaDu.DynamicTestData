// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Provides named test data rows for parameterized testing scenarios.
/// </summary>
/// <typeparam name="TRow">The type of data rows produced by this source.</typeparam>
/// <param name="argsCode">The default argument processing strategy.</param>
/// <param name="propertyCode">The default property inclusion strategy.</param>
/// <remarks>
/// <para>
/// This specialized data source combines:
/// <list type="bullet">
///   <item>Named test case support through <see cref="INamedRows{TRow}"/></item>
///   <item>Dynamic data generation from <see cref="DynamicDataRowSource{TDataHolder, TRow}"/></item>
///   <item>Configurable argument processing via <see cref="ArgsCode"/></item>
/// </list>
/// </para>
/// <para>
/// Typical use cases include:
/// <list type="bullet">
///   <item>Named data-driven tests</item>
///   <item>Parameterized test fixtures</item>
///   <item>Scenarios requiring test case identification</item>
/// </list>
/// </para>
/// </remarks>
public abstract class DynamicNamedDataRowSource<TRow>(ArgsCode argsCode, PropertyCode propertyCode)
    : DynamicDataRowSource<INamedDataRowHolder<TRow>, TRow>(argsCode, propertyCode),
      INamedRows<TRow>
{
    /// <summary>
    /// Retrieves named test data rows with optional strategy modification.
    /// </summary>
    /// <param name="testMethodName">The name of the associated test method.</param>
    /// <param name="argsCode">Optional argument processing override.</param>
    /// <returns>
    /// Matching test data rows or null if no matches found.
    /// </returns>
    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode)
        => DataHolder?.GetRows(testMethodName, argsCode);

    /// <summary>
    /// Retrieves named test data rows with strategy and property filtering.
    /// </summary>
    /// <param name="testMethodName">The name of the associated test method.</param>
    /// <param name="argsCode">Argument processing override.</param>
    /// <param name="propertyCode">Property inclusion override.</param>
    /// <returns>
    /// Matching test data rows or null if no matches found.
    /// </returns>
    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode, PropertyCode? propertyCode)
        => DataHolder?.GetRows(testMethodName, argsCode, propertyCode);
}