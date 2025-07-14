// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;
/// <summary>
/// Represents an interface for creating strongly-typed test data rows with associated test data.
/// </summary>
/// <typeparam name="TRow">The type of the data row that will be created.</typeparam>
/// <typeparam name="TTestData">The type of the test data associated with the row.
/// Must be a non-null type implementing <see cref="ITestData"/>.</typeparam>
public interface ITypedTestDataRow<TRow, TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Creates a new strongly-typed test data row instance with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to associate with the new row.
    /// Must not be null and must implement <see cref="ITestData"/>.</param>
    /// <returns>A new <see cref="ITestDataRow{TRow, TTestData}"/> instance containing the provided test data.</returns>
    ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData testData);
}