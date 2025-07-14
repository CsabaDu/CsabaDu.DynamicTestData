// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;
/// <summary>
/// Represents a single row of test data that can be used in a test case.
/// Extends <see cref="INamedTestCase"/> to provide naming capabilities.
/// </summary>
public interface ITestDataRow
: INamedTestCase
{
    /// <summary>
    /// Gets the parameter values for this test data row using the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use for parameter retrieval.</param>
    /// <returns>An array of parameter values (which may include nulls).</returns>
    object?[] GetParams(IDataStrategy dataStrategy);

    /// <summary>
    /// Gets the test data associated with this row.
    /// </summary>
    /// <returns>The <see cref="ITestData"/> instance containing the test data.</returns>
    ITestData GetTestData();
}

/// <summary>
/// Represents a strongly-typed test data row that can be converted to a specific type.
/// </summary>
/// <typeparam name="TRow">The type to which this test data row can be converted.</typeparam>
public interface ITestDataRow<TRow>
: ITestDataRow
{
    /// <summary>
    /// Converts this test data row to the specified type using the given data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use for conversion.</param>
    /// <returns>The converted row of type <typeparamref name="TRow"/>.</returns>
    TRow Convert(IDataStrategy dataStrategy);
}

/// <summary>
/// Represents a strongly-typed test data row with associated strongly-typed test data.
/// </summary>
/// <typeparam name="TRow">The type to which this test data row can be converted.</typeparam>
/// <typeparam name="TTestData">The type of the test data, which must be a non-null <see cref="ITestData"/>.</typeparam>
public interface ITestDataRow<TRow, TTestData>
: ITestDataRow<TRow>,
    ITypedTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Gets the strongly-typed test data associated with this row.
    /// </summary>
    TTestData TestData { get; }
}