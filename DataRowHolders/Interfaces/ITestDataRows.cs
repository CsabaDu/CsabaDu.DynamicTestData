// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a provider of test data rows and their associated data strategy.
/// This interface defines the contract for types that can supply test cases
/// and determine how they should be processed.
/// </summary>
public interface ITestDataRows
{
    /// <summary>
    /// Gets an enumerable collection of test data rows.
    /// </summary>
    /// <returns>
    /// A sequence of <see cref="ITestDataRow"/> objects representing individual test cases,
    /// or null if no test data rows are available.
    /// </returns>
    /// <remarks>
    /// The returned collection may be empty or null to indicate no test cases are available.
    /// Consumers should handle both cases appropriately.
    /// </remarks>
    IEnumerable<ITestDataRow>? GetTestDataRows();

    /// <summary>
    /// Gets the data strategy to be used for processing test data rows.
    /// </summary>
    /// <param name="argsCode">
    /// Optional argument code that may influence the data strategy selection.
    /// Can be used to customize how test data is processed.
    /// </param>
    /// <returns>
    /// An <see cref="IDataStrategy"/> instance that defines how test data should be handled.
    /// Implementations should never return null.
    /// </returns>
    /// <remarks>
    /// The returned strategy determines aspects like argument formatting,
    /// expected result handling, and other processing behaviors.
    /// </remarks>
    IDataStrategy GetDataStrategy(ArgsCode? argsCode);
    IDataStrategy GetDataStrategy(ArgsCode? argsCode, PropertyCode? propertyCode);
}