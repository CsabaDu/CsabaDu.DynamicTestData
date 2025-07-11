// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

/// <summary>
/// Represents a single row of test dataRows, including its associated arguments and parameters.
/// </summary>
/// <remarks>This interface is typically used in testing frameworks to encapsulate a set of input parameters for a
/// test case. Implementations of this interface provide access to the arguments' metadata and the actual parameter
/// values.</remarks>
public interface ITestDataRow
: INamedTestCase
{
    /// <summary>
    /// Gets the parameters associated with the current test dataRows row.
    /// </summary>
    /// <returns>An array of objects representing the parameters. The array may include null values if any parameter is not set.</returns>
    object?[] GetParams(IDataStrategy dataStrategy);
    ITestData GetTestData();
}

/// <summary>
/// Represents a row of test data that can be converted to a specific type.
/// </summary>
/// <typeparam name="TRow">The type to which the test data row will be converted.</typeparam>
public interface ITestDataRow<TRow>
: ITestDataRow
{
    TRow Convert(IDataStrategy dataStrategy);
}

/// <summary>
/// Represents a test data row that provides strongly-typed access to both the row data and its associated test data.
/// </summary>
/// <remarks>This interface extends <see cref="ITestDataRow{TRow}"/> and <see cref="ITypedTestDataRow{TRow,
/// TTestData}"/>,  combining functionality for accessing row data and its associated test data in a strongly-typed
/// manner.</remarks>
/// <typeparam name="TRow">The type of the row data.</typeparam>
/// <typeparam name="TTestData">The type of the associated test data. Must implement <see cref="ITestData"/> and cannot be null.</typeparam>
public interface ITestDataRow<TRow, TTestData>
: ITestDataRow<TRow>,
ITypedTestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    TTestData TestData { get; }
}
