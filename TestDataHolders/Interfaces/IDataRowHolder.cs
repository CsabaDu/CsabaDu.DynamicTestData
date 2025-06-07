// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IDataRowHolder
: IEnumerable<ITestDataRow>;

public interface IDataRowHolder<TRow>
: IDataRowHolder,
IRows<TRow>
where TRow : notnull
{
    IEnumerable<ITestDataRow<TRow>> GetTestDataRows();
}

public interface IDataRowHolder<TTestData, TRow>
: IDataRowHolder<TRow>,
ICreateTestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    void Add(ITestDataRow<TTestData, TRow> testDataRow);
}

public interface ICreateTestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    ITestDataRow<TTestData, TRow> CreateTestDataRow(IDataStrategy dataStrategy, TTestData testData);
}