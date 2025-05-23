// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Defines a method to retrieve the expected value of a test case.
/// </summary>
/// <remarks>This interface is typically implemented by classes that represent test cases or scenarios where an
/// expected result needs to be compared against an actual result.</remarks>
public interface IExpected
{
    /// <summary>
    /// Gets the expected value of the test case.
    /// </summary>
    object GetExpected();
}
