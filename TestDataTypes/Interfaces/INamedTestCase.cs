// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;
/// <summary>
/// Represents a test case that provides a display name for identification and reporting purposes.
/// </summary>
/// <remarks>
/// <para>
/// This interface combines the capability to provide a human-readable test case name
/// with equality comparison functionality. Implement this interface when test cases
/// need to be uniquely identifiable and displayable in test reports.
/// </para>
/// <para>
/// The equality comparison allows for distinguishing between different test cases
/// while the display name provides meaningful context for test results.
/// </para>
/// </remarks>
public interface INamedTestCase : IEquatable<INamedTestCase>
{
    /// <summary>
    /// Gets the display name of the test case.
    /// </summary>
    /// <returns>
    /// A string representing the human-readable name of the test case.
    /// This name should be descriptive enough to identify the specific test scenario
    /// when viewed in test reports or output logs.
    /// </returns>
    string GetTestCaseName();
}