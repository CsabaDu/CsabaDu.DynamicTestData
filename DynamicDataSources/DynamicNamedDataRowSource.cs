// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Represents a dynamic data source that provides named rows of type <typeparamref name="TRow"/>  for use in test
/// methods or other scenarios requiring parameterized data.
/// </summary>
/// <remarks>This class extends <see cref="DynamicDataRowSource{TRow}"/> and implements <see
/// cref="INamedRows{TRow}"/>  to support retrieving rows by name and optional argument codes. It is designed for
/// scenarios where  test methods or other consumers require named data rows.</remarks>
/// <typeparam name="TRow">The type of the rows provided by the data source.</typeparam>
/// <param name="argsCode"></param>
/// <param name="expectedResultType"></param>
public abstract class DynamicNamedDataRowSource<TRow>(ArgsCode argsCode, PropertyCode propertyCode)
: DynamicDataRowSource<INamedDataRowHolder<TRow>, TRow>(argsCode, propertyCode),
INamedRows<TRow>
{
    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode)
    => DataHolder?.GetRows(testMethodName, argsCode);

    public IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode, PropertyCode? propertyCode)
    => DataHolder?.GetRows(testMethodName, argsCode, propertyCode);
}
