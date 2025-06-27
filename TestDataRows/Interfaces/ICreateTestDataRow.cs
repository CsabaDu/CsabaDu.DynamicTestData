// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

public interface ICreateTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    ITestDataRow<TRow, TTestData> CreateTestDataRow(
        TTestData testData);
}