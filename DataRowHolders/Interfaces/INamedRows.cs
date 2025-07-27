// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a provider of strongly-typed data rows that can be retrieved based on nullable <see cref="ArgsCode"/> value
/// and supports generating a test case display name using the test method name.
/// </summary>
/// <typeparam name="TRow">The type of the rows in the collection.</typeparam>
public interface INamedRows<TRow>
{
    /// <summary>
    /// Retrieves a sequence of named and typed data rows configured by the given nullable <see cref="ArgsCode"/> parameter.
    /// </summary>
    /// <param name="testMethodName">
    /// The name of the associated test method used for generating display names.
    /// May be null for unnamed test cases.
    /// </param>
    /// <param name="argsCode">
    /// Nullable <see cref="ArgsCode"/> that controls how test data is generated.
    /// When null, implementations should use default argument handling.
    /// </param>
    /// <returns>
    /// An enumerable sequence of <typeparamref name="TRow"/> instances matching the criteria,
    /// or null if no matching rows are available.
    /// </returns>
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode);
    IEnumerable<TRow>? GetRows(string? testMethodName, ArgsCode? argsCode, PropertyCode? propertyCode);
}