// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

/// <summary>
/// Represents a test case object that encapsulates a test case identifier or description.
/// </summary>
/// <remarks>This class implements the <see cref="ITestCaseName"/> interface and provides a simple way to represent a
/// test case. The <see cref="Equals(ITestCaseName?)"/> method is not intended for use and will throw an exception if
/// called.</remarks>
/// <param name="testCase"></param>
public class TestCaseObject(string testCase)
: ITestCaseName
{
    public string TestCase => testCase;

    public bool Equals(ITestCaseName? other)
    => throw new InvalidOperationException("Tests shouldn't access this method.");
}
