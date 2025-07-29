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
    ArgsCode ArgsCode { get; }

    PropertyCode PropertyCode { get; }
}