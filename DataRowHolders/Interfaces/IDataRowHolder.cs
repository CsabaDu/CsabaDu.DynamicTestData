// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface IDataRowHolder
: ITestDataRows
{
    IDataStrategy DataStrategy { get; }
}

public interface IDataRowHolder<TRow>
: IDataRowHolder,
ITestDataType,
IRows<TRow>
{
    IDataRowHolder<TRow> GetDataRowHolder(IDataStrategy dataStrategy);
}

public interface IDataRowHolder<TRow, TTestData>
: IReadOnlyCollection<ITestDataRow>,
IDataRowHolder<TRow>,
ICreateTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    void Add(ITestDataRow<TRow, TTestData> testDataRow);
}
