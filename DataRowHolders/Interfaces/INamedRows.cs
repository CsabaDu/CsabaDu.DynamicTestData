// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Provides named access to typed test cases.
/// </summary>
/// <typeparam name="TRow">Row type.</typeparam>
public interface INamedRows<TRow>
{
    /// <summary>
    /// Retrieves test cases with named context.
    /// </summary>
    /// <param name="testMethodName">
    /// Associated test name (optional).
    /// </param>
    /// <param name="argsCode">
    /// Processing modifier.
    /// </param>
    /// <returns>
    /// Sequence of cases or null.
    /// </returns>
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode);

    /// <summary>
    /// Retrieves test cases with named context and property control.
    /// </summary>
    /// <param name="testMethodName">
    /// Associated test name (optional).
    /// </param>
    /// <param name="argsCode">
    /// Processing modifier.
    /// </param>
    /// <param name="propsCode">
    /// Property inclusion modifier.
    /// </param>
    /// <returns>
    /// Sequence of cases or null.
    /// </returns>
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode, PropsCode? propsCode);
}
