// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;
/// <summary>
/// Represents a named test data row that provides conversion capabilities with test method context.
/// Extends <see cref="ITestDataRow{TRow}"/> to include test method naming support.
/// </summary>
/// <typeparam name="TRow">The target type for row conversion</typeparam>
public interface INamedTestDataRow<TRow>
    : ITestDataRow<TRow>
{
    /// <summary>
    /// Converts the test data row to the target type with additional naming context.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use for conversion</param>
    /// <param name="testMethodName">Optional name of the test method this row belongs to.
    /// May be used for context-specific conversion logic.</param>
    /// <returns>The converted row of type <typeparamref name="TRow"/></returns>
    TRow Convert(IDataStrategy dataStrategy, string? testMethodName);
}