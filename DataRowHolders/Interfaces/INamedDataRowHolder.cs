// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface INamedDataRowHolder<TRow>
: IDataRowHolder<TRow>,
INamedRows<TRow>
{
    INamedDataRowHolder<TRow> GetNamedDataRowHolder(IDataStrategy dataStrategy, string? testMethodName);
}
