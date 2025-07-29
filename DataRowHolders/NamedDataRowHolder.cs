// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

public abstract class NamedDataRowHolder<TRow, TTestData>
: DataRowHolder<TRow, TTestData>,
INamedDataRowHolder<TRow>
where TTestData : notnull, ITestData
{
    protected NamedDataRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
    }

    protected NamedDataRowHolder(
        IDataRowHolder<TRow, TTestData> other,
        IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
    }

    public static IEnumerable<TRow>? GetRows(
        [NotNull] INamedDataRowHolder<TRow> dataHolder,
        string? testMethodName,
        IDataStrategy? dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(
            dataHolder,
            nameof(dataHolder));

        var testDataRows =
            dataHolder.GetTestDataRows();

        dataStrategy ??= dataHolder.DataStrategy;

        return testDataRows?.Select(
            tdr => (tdr as INamedTestDataRow<TRow>)
            !.Convert(
                dataStrategy,
                testMethodName));
    }

    public IEnumerable<TRow>? GetRows(
        string? testMethodName,
        ArgsCode? argsCode)
    => GetRows(
        this,
        testMethodName,
        GetDataStrategy(argsCode));

    public IEnumerable<TRow>? GetRows(
        string? testMethodName,
        ArgsCode? argsCode,
        PropertyCode? propertyCode)
    => GetRows(
        this,
        testMethodName,
        GetDataStrategy(
            argsCode,
            propertyCode));
}