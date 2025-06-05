// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

public interface ITestDataRowCollecttion
: ITestDataType,
IEnumerable<ITestDataRow>;

public interface ITestDataRowCollecttion<TRow>
: ITestDataRowCollecttion
where TRow : notnull
{
    IEnumerable<ITestDataRow<TRow>> GetTestDataRows();
    IEnumerable<TRow> GetRows();
}

public interface ITestDataRowCollecttion<TTestData, TRow>
: ITestDataRowCollecttion<TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    void Add(ITestDataRow<TTestData, TRow> testDataRow);
    ITestDataRow<TTestData, TRow> CreateTestDataRow(TTestData testData, ArgsCode argsCode, bool? withExpected);
}
