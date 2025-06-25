// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicNamedDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<TRow>(argsCode, expectedResultType),
INamedRows<TRow>
{
    private INamedRows<TRow>? GetNamedRows()
    => DataRowHolder as INamedRows<TRow>;

    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode)
    => GetNamedRows()?.GetRows(testMethodName, argsCode);

    public IEnumerable<INamedTestDataRow<TRow>>? GetTestDataRows(string? testMethodName, ArgsCode? argsCode)
    => GetNamedRows()?.GetTestDataRows(testMethodName, argsCode);
}
