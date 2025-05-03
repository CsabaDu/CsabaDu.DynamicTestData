// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public sealed class TestDataChildrenInstances
{
    /// <summary>
    /// A const instance of <see cref="TestDoubles.TestDataChild"/> used in tests, initialized with actual definition, result, and exit mode.
    /// </summary>
    public static readonly TestDataChild TestDataChildInstance
        = new(ActualDefinition, string.Empty, ExpectedString);

    /// <summary>
    /// A const instance of <see cref="TestDataReturnsChildInstance<DummyEnum>"/> used in tests, initialized with actual definition.
    /// </summary>
    public static readonly TestDataReturnsChild<DummyEnum> TestDataReturnsChildInstance
        = new(ActualDefinition, DummyEnumTestValue);

    /// <summary>
    /// A const instance of <see cref="TestDataThrowsChildInstance"/> used in tests, initialized with actual definition, parameter, and error message.
    /// </summary>
    public static readonly TestDataThrowsChild<DummyException> TestDataThrowsChildInstance
        = new(ActualDefinition, DummyExceptionInstance);
}
