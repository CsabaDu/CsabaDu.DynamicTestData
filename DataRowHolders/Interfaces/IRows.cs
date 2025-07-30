// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Provides typed access to test data rows.
/// </summary>
/// <typeparam name="TRow">The target row type.</typeparam>
public interface IRows<TRow>
{
    /// <summary>
    /// Retrieves typed test cases.
    /// </summary>
    /// <param name="argsCode">
    /// Optional processing modifier.
    /// </param>
    /// <returns>
    /// Sequence of typed cases or null if none available.
    /// </returns>
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode);

    /// <summary>
    /// Retrieves typed test cases with property control.
    /// </summary>
    /// <param name="argsCode">
    /// Processing modifier.
    /// </param>
    /// <param name="propertyCode">
    /// Property inclusion modifier.
    /// </param>
    /// <returns>
    /// Sequence of typed cases or null if none available.
    /// </returns>
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode, PropertyCode? propertyCode);
}