// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicNamedDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<TRow>(argsCode, expectedResultType),
INamedRows<TRow>
{
    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode)
    => (DataRowHolder as INamedRows<TRow>)?.GetRows(testMethodName, argsCode);
}
