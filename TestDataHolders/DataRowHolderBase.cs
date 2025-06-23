// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders;

public abstract class DataRowHolderBase<TRow>(IDataStrategy dataStrategy)
: IDataRowHolder<TRow>
{
    private protected DataRowHolderBase(
        ITestData testData,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
            testData,
            nameof(testData));

    private protected DataRowHolderBase(
        IDataRowHolder? other,
        IDataStrategy dataStrategy)
    : this(dataStrategy)
    => ArgumentNullException.ThrowIfNull(
            other,
            nameof(other));

    public IDataStrategy DataStrategy { get; init; } = dataStrategy
        ?? throw new ArgumentNullException(nameof(dataStrategy));

    public abstract Type TestDataType { get; }

    public IEnumerable<TRow>? GetRows()
    => (GetDataRowHolder(DataStrategy) as IEnumerable<ITestDataRow>)
        ?.Select(tdr => (tdr as ITestDataRow<TRow>)
        !.Convert(DataStrategy));

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => argsCode.HasValue ?
        GetDataRowHolder(GetDataStrategy(argsCode.Value))
        .GetRows()
        : GetRows();

    public abstract IDataRowHolder<TRow> GetDataRowHolder(
        IDataStrategy dataStrategy);

    protected IDataStrategy GetDataStrategy(ArgsCode argsCode)
    => argsCode == DataStrategy.ArgsCode ?
        DataStrategy
        : new DataStrategy(
            argsCode,
            DataStrategy.WithExpected);
}
