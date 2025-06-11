// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IDataStrategy
{
    /// <summary>
    /// Gets the <see cref="TestDataTypes.ArgsCode"/> type enum which determines the strategy of creating test parameters.
    /// </summary>
    ArgsCode ArgsCode { get; }

    /// <summary>
    /// Gets a value indicating whether the test parameters object array shall contain the expected result element.
    /// </summary>
    bool? WithExpected { get; }
}
