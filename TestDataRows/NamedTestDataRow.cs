// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

/// <summary>
/// Represents a named test data row that provides functionality to convert test data into a specific row format.
/// </summary>
/// <remarks>This abstract class serves as a base for creating named test data rows that can be converted into a
/// specific row format using a provided data strategy and optional test method name. It extends <see
/// cref="TestDataRow{TRow, TTestData}"/> and implements <see cref="INamedTestDataRow{TRow}"/>.</remarks>
/// <typeparam name="TRow">The type of the row produced by the conversion.</typeparam>
/// <typeparam name="TTestData">The type of the test data associated with the row. Must be non-null and implement <see cref="ITestData"/>.</typeparam>
/// <param name="testData"></param>
public abstract class NamedTestDataRow<TRow, TTestData>(TTestData testData)
: TestDataRow<TRow, TTestData>(testData),
INamedTestDataRow<TRow>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Converts the provided data strategy into an instance of <typeparamref name="TRow"/>.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to be converted. This parameter cannot be null.</param>
    /// <param name="testMethodName">The name of the test method associated with the conversion, or <see langword="null"/> if no test method is
    /// specified.</param>
    /// <returns>An instance of <typeparamref name="TRow"/> representing the converted data.</returns>
    public abstract TRow Convert(IDataStrategy dataStrategy, string? testMethodName);
}