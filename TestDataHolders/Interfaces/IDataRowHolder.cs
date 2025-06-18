// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IDataRowHolder
: ITestDataType;

public interface IDataRowHolder<TRow>
: IDataRowHolder,
IRows<TRow>
{

}

public interface IDataRowHolder<TTestData, TRow>
: IEnumerable<ITestDataRow>,
IDataRowHolder<TRow>,
ICreateTestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
{
    void Add(ITestDataRow<TTestData, TRow> testDataRow);
}
