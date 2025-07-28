// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes.Interfaces;

/// <summary>
/// Represents a strategy interface for handling test data, combining argument conversion
/// capabilities with equality comparison and expected result management.
/// </summary>
public interface IDataStrategy
: IEquatable<IDataStrategy>
{
    /// <summary>
    /// Gets the <see cref="Statics.ArgsCode"/> that defines how to convert 'TestData' records to arguments.
    /// </summary>
    /// <value>
    /// An <see cref="Statics.ArgsCode"/> enumeration value that specifies the conversion method
    /// for transforming test data records into method arguments.
    /// </value>
    ArgsCode ArgsCode { get; }

    PropertyCode PropertyCode { get; }
}