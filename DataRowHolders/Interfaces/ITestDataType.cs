// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Represents a typed test data container, providing access to the underlying test data type.
/// This interface enables type-safe operations and reflection scenarios where the specific
/// test data type needs to be known at runtime.
/// </summary>
/// <remarks>
/// Implementations of this interface are typically used when the test framework needs to
/// inspect or operate on the concrete type of test data being processed, enabling:
/// <list type="bullet">
///   <item>Type verification and validation</item>
///   <item>Dynamic test case generation based on data type</item>
///   <item>Reflection-based operations on test data</item>
/// </list>
/// </remarks>
public interface ITestDataType
{
    /// <summary>
    /// Gets the <see cref="System.Type"/> of the test data contained by this instance.
    /// </summary>
    /// <value>
    /// The <see cref="System.Type"/> object representing the type of the test data.
    /// </value>
    /// <remarks>
    /// This property should always return a non-null Type object. For generic test data types,
    /// this should return the closed, constructed type (e.g., <c>MyTestData&lt;string&gt;</c>)
    /// rather than the open generic type definition.
    /// </remarks>
    Type TestDataType { get; }
}