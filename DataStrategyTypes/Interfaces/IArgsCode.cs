// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes.Interfaces;

public interface IArgsCode
{
    /// <summary>
    /// Gets the code representing how to convert the 'TestData' records to arguments.
    /// </summary>
    ArgsCode ArgsCode { get; }
}
