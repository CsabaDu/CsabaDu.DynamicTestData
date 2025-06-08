// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

/// <summary>
/// Represents a concrete record for test data with a definition, result, and exit mode.
/// </summary>
/// <param name="Definition">The definition of the test case.</param>
/// <param name="ExitMode">The exit mode of the test.</param>
/// <param name="Result">The result of the test.</param>
public record TestDataChild(
    string Definition,
    string ExitMode,
    string Result)
: TestData(Definition, ExitMode, Result)
{
    public override object?[] PropertiesToParams(bool withExpected)
    => [withExpected];
}
