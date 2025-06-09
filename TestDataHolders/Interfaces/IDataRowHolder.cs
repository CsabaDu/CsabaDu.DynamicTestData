// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IDataRowHolder
: IEnumerable<ITestDataRow>;

public interface IDataRowHolder<TRow>
: IDataRowHolder,
IRows<TRow>

{
    IEnumerable<ITestDataRow<TRow>> GetTestDataRows();
}

public interface IDataRowHolder<TTestData, TRow>
: IDataRowHolder<TRow>,
ICreateTestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData

{
    void Add(ITestDataRow<TTestData, TRow> testDataRow);
}
