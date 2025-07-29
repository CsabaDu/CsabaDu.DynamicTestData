// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a provider of strongly-typed data rows that can be retrieved based on nullable <see cref="ArgsCode"/> value.
/// </summary>
/// <typeparam name="TRow">The type of rows to be returned by this provider.</typeparam>
/// <remarks>
/// This interface is typically implemented by test data sources that need to provide
/// typed data rows to test cases. The <see cref="GetRows"/> method allows for dynamic
/// row generation based on input arguments.
/// </remarks>
public interface IRows<TRow>
{
    /// <summary>
    /// Retrieves a sequence of typed data rows configured by the given nullable <see cref="ArgsCode"/> parameter.
    /// </summary>
    /// <param name="argsCode">
    /// Optional argument code that may influence how the rows are to be configured.
    /// </param>
    /// <returns>
    /// An enumerable sequence of <typeparamref name="TRow"/> instances, or <c>null</c> if no rows are available.
    /// </returns>
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode);
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropertyCode? propertyCode);
}