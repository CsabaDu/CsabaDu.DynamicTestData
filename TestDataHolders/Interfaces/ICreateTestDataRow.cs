// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface ICreateTestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
{
    ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData);
}