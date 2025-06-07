// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IRows<TRow>
where TRow : notnull
{
    IEnumerable<TRow>? GetRows();

}
