// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

/// <summary>
/// Represents a single test case's data with parameter retrieval capabilities.
/// </summary>
/// <remarks>
/// <para>
/// Serves as a container for all test parameters and expected results needed to execute a test case.
/// Works in conjunction with <see cref="IDataStrategy"/> to control parameter exposure.
/// </para>
/// <para>
/// Implements <see cref="INamedTestCase"/> to provide consistent test case identification.
/// </para>
/// </remarks>
public interface ITestDataRow : INamedTestCase
{
    /// <summary>
    /// Retrieves test parameters formatted according to the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">
    /// Determines which parameters to include and their formatting.
    /// </param>
    /// <returns>
    /// Array of parameter values ready for test execution.
    /// May include null values where applicable.
    /// </returns>
    object?[] GetParams(IDataStrategy dataStrategy);

    /// <summary>
    /// Provides access to the complete test data instance.
    /// </summary>
    /// <returns>
    /// The underlying <see cref="ITestData"/> implementation containing all test details.
    /// </returns>
    ITestData GetTestData();
}

/// <summary>
/// Represents a test data row that can be converted to a specific model type.
/// </summary>
/// <typeparam name="TRow">
/// The target type for conversion, typically a DTO or domain model.
/// </typeparam>
/// <remarks>
/// Enables type-safe conversion of test data to system-under-test input models.
/// </remarks>
public interface ITestDataRow<TRow> : ITestDataRow
{
    /// <summary>
    /// Converts the test data to the specified type using the given strategy.
    /// </summary>
    /// <param name="dataStrategy">
    /// Controls how test data properties are mapped during conversion.
    /// </param>
    /// <returns>
    /// A new instance of <typeparamref name="TRow"/> populated with test data.
    /// </returns>
    TRow Convert(IDataStrategy dataStrategy);
}

/// <summary>
/// Represents a strongly-typed test data row with associated typed test data.
/// </summary>
/// <typeparam name="TRow">
/// The target conversion type for the test data row.
/// </typeparam>
/// <typeparam name="TTestData">
/// The specific type of test data (must implement <see cref="ITestData"/> and be non-nullable).
/// </typeparam>
/// <remarks>
/// Combines type-safe conversion with direct access to typed test data properties.
/// </remarks>
public interface ITestDataRow<TRow, TTestData> : ITestDataRow<TRow>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Gets the strongly-typed test data instance.
    /// </summary>
    /// <value>
    /// The complete test data with type-specific access to all test parameters and expectations.
    /// </value>
    TTestData TestData { get; }
}