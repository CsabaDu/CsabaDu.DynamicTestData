// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

/// <summary>
/// Represents a record for test data returns with a specified structure type.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
public record TestDataReturnsChild<TStruct>(
    string Definition,
    TStruct Expected)
: TestDataReturns<TStruct>(Definition, Expected)
where TStruct : struct
{
    public override object?[] PropertiesToArgs(bool withExpected)
    => throw new InvalidOperationException("Tests shouldn't access this method.");
}
