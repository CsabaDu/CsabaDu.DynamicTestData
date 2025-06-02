// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

/// <summary>
/// Represents a single row of test data, including its associated arguments and parameters.
/// </summary>
/// <remarks>This interface is typically used in testing frameworks to encapsulate a set of input parameters for a
/// test case. Implementations of this interface provide access to the arguments' metadata and the actual parameter
/// values.</remarks>
public interface ITestDataRow
{
    /// <summary>
    /// Gets the <see cref="TestDataTypes.ArgsCode"/> type enum which determines the strategy of creating test parameters.
    /// </summary>
    ArgsCode ArgsCode { get; }

    /// <summary>
    /// Retrieves the parameters associated with the current test data.
    /// </summary>
    /// <returns>An array of objects representing the parameters. The array may include null values if any parameter is not set.</returns>
    object?[] GetParameters();
}