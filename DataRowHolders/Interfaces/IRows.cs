// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a collection of rows that can be retrieved based on the specified arguments.
/// </summary>
/// <typeparam name="TRow">The type of the rows in the collection.</typeparam>
public interface IRows<TRow>
{
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode);
}
