// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

/// <summary>
/// Represents a factory for creating <see cref="ITestDataRow{TRow, TTestData}"/> instances
/// that associate test data with strongly-typed rows.
/// </summary>
/// <typeparam name="TRow">The target row type to be created.</typeparam>
/// <typeparam name="TTestData">The type of test data to be associated with the row, which must be non-null and implement <see cref="ITestData"/>.</typeparam>
public interface ITestDataRowFactory<TRow, TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Creates a new test data row instance associated with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to associate with the row. Must not be null.</param>
    /// <returns>
    /// A new <see cref="ITestDataRow{TRow, TTestData}"/> instance containing the specified test
    /// data.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is null.</exception>
    ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData testData);
}
