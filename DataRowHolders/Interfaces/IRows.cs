// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface IRows<TRow>
{
    IEnumerable<TRow>? GetRows();
    IEnumerable<TRow>? GetRows(ArgsCode? argsCode);
}
