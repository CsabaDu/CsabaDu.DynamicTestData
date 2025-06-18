// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;
using CsabaDu.DynamicTestData.TestDataHolders.Named.Interfaces;

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicNamedDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<TRow>(argsCode, expectedResultType),
INamedRows<TRow>
{
    public IEnumerable<TRow>? GetNamedRows(string? testMethodName)
    => (DataRowHolder as INamedRows<TRow>)?.GetNamedRows(testMethodName);

    public IEnumerable<TRow>? GetNamedRows(string? testMethodName, ArgsCode? argsCode)
    => (DataRowHolder as INamedRows<TRow>)?.GetNamedRows(testMethodName);
}

public abstract class DynamicNamedDataSource(ArgsCode argsCode, Type? expectedResultType)
: DynamicNamedDataSource<object?[]>(argsCode, expectedResultType)
{
    protected override ITestDataRow<TTestData, object?[]> CreateTestDataRow<TTestData>(TTestData testData)
    {
        throw new NotImplementedException();
    }

    protected override void InitDataRowHolder<TTestData>(TTestData testData)
    {
        throw new NotImplementedException();
    }
}