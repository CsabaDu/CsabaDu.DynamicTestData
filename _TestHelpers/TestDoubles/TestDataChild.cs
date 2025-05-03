// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

/// <summary>
/// Represents a concrete record for test data with a definition, result, and exit mode.
/// </summary>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ExitMode">The exit mode of the test data.</param>
/// <param name="TestResult">The result of the test data.</param>
public sealed record TestDataChild(string Definition, string ExitMode, string TestResult) : TestData(Definition, ExitMode, TestResult)
{
    ///// <summary>
    ///// Gets the result of the test data.
    ///// </summary>
    //public override string Result => TestResult;
}
