// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;/// <summary>
/// Provides access to test data rows and their processing strategy.
/// </summary>
/// <remarks>
/// Serves as the foundation for test data providers, combining:
/// <list type="bullet">
///   <item>Test case enumeration</item>
///   <item>Data processing strategy management</item>
/// </list>
/// </remarks>
public interface ITestDataRows
{
    /// <summary>
    /// Retrieves all available test cases.
    /// </summary>
    /// <returns>
    /// Sequence of test cases or null if none available.
    /// </returns>
    /// <remarks>
    /// Consumers should handle both null and empty sequences appropriately.
    /// </remarks>
    IEnumerable<ITestDataRow>? GetTestDataRows();

    /// <summary>
    /// Gets the processing strategy for test data.
    /// </summary>
    /// <param name="argsCode">
    /// Optional strategy modifier.
    /// </param>
    /// <returns>
    /// Configured data strategy (never null).
    /// </returns>
    IDataStrategy GetDataStrategy(ArgsCode? argsCode);

    /// <summary>
    /// Gets the processing strategy for test data with property control.
    /// </summary>
    /// <param name="argsCode">
    /// Strategy modifier.
    /// </param>
    /// <param name="propertyCode">
    /// Property inclusion modifier.
    /// </param>
    /// <returns>
    /// Configured data strategy (never null).
    /// </returns>
    IDataStrategy GetDataStrategy(ArgsCode? argsCode, PropertyCode? propertyCode);
}