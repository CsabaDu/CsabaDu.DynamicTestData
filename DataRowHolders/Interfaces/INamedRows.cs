// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface INamedRows<TRow>
{
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode);
    IEnumerable<INamedTestDataRow<TRow>>? GetTestDataRows(string? testMethodName, ArgsCode? argsCode);
}
