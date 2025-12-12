// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataRows.Interfaces;

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Factory for creating typed test data rows.
/// </summary>
/// <typeparam name="TRow">Row type.</typeparam>
/// <typeparam name="TTestData">Test data type (non-nullable ITestData).</typeparam>
public interface ITestDataRowFactory<TRow, TTestData>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Creates a new test case row.
    /// </summary>
    /// <param name="testData">Test data to wrap (cannot be null).</param>
    /// <returns>
    /// New typed test case.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if testData is null.</exception>
    ITestDataRow<TRow, TTestData> CreateTestDataRow(TTestData testData);
}