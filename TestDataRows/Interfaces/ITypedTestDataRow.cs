// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

/// <summary>
/// Represents a factory for creating strongly-typed test data rows.
/// </summary>
/// <typeparam name="TRow">The type of the row data.</typeparam>
/// <typeparam name="TTestData">The type of the test data, which must implement <see cref="ITestData"/> and cannot be null.</typeparam>
public interface ITypedTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    ITestDataRow<TRow, TTestData> CreateTestDataRow(
        TTestData testData);
}