// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes.Interfaces;

/// <summary>
/// Represents a strategy interface for handling test data, combining argument conversion
/// capabilities with equality comparison and expected result management.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IArgsCode"/> for argument conversion and
/// <see cref="IEquatable{T}"/> for equality comparison, while adding specific
/// test data strategy functionality.
/// </remarks>
public interface IDataStrategy : IArgsCode, IEquatable<IDataStrategy>
{
    /// <summary>
    /// Gets a value indicating whether the test parameters object array should include
    /// the expected result element.
    /// </summary>
    /// <value>
    /// <para>
    /// A nullable boolean where:
    /// </para>
    /// <list type="bullet">
    ///   <item><description><see langword="true"/> - the expected result should be included in test parameters</description></item>
    ///   <item><description><see langword="false"/> - the expected result should be excluded from test parameters</description></item>
    ///   <item><description><see langword="null"/> - use the default behavior determined by the test framework</description></item>
    /// </list>
    /// </value>
    bool? WithExpected { get; }
}