// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Combines typed data holding with named access.
/// </summary>
/// <typeparam name="TRow">Row type.</typeparam>
public interface INamedDataRowHolder<TRow>
    : IDataRowHolder<TRow>,
      INamedRows<TRow>
{
    // Merges strategy management with named case retrieval
}
