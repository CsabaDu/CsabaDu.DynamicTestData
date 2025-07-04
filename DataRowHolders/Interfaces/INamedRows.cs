// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a collection of rows that can be retrieved by a test method name and optional arguments code.
/// </summary>
/// <typeparam name="TRow">The type of the rows in the collection.</typeparam>
public interface INamedRows<TRow>
{
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode);
}
