// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

/// <summary>
/// Represents a single row of test data, including its associated arguments and parameters.
/// </summary>
/// <remarks>This interface is typically used in testing frameworks to encapsulate a set of input parameters for a
/// test case. Implementations of this interface provide access to the arguments' metadata and the actual parameter
/// values.</remarks>
public interface ITestDataRow
: ITestCaseName
{
    /// <summary>
    /// Gets the parameters associated with the current test data row.
    /// </summary>
    /// <returns>An array of objects representing the parameters. The array may include null values if any parameter is not set.</returns>
    object?[] Params { get; }
    IDataStrategy DataStrategy { get; }

    string? GetDisplayName(string? testMethodName);
}

public interface ITestDataRow<TRow>
: ITestDataRow
where TRow: notnull
{
    TRow Convert();
}

public interface ITestDataRow<TTestData, TRow>
: ITestDataRow<TRow>
where TTestData : notnull, ITestData
where TRow : notnull;
