// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

/// <summary>
/// Provides a set of constant and const parameters for testing purposes.
/// </summary>
public sealed class Params
{
    public const string TestMethodName = "TestMethod";

    /// <summary>
    /// A constant string parameter.
    /// </summary>
    public const string Parameter = "parameter";

    /// <summary>
    /// A const string representing the actual definition used in tests.
    /// </summary>
    public const string ActualDefinition = "Test Definition";

    /// <summary>
    /// A const string representing the expected string used in tests.
    /// </summary>
    public const string ExpectedString = "Test Expected";

    /// <summary>
    /// A const string representing the name of the Expected propety of a TestCaseName type used in tests.
    /// </summary>
    public const string ExpectedPropertyName = "Expected";

    /// <summary>
    /// A const string representing the actual result used in tests.
    /// </summary>
    public const string ActualResult = "Test Result";

    /// <summary>
    /// A const string representing the actual exit mode used in tests.
    /// </summary>
    public const string ActualExitMode = "Test Exit Mode";

    /// <summary>
    /// A constant string representing the definition name of the test data.
    /// </summary>
    public const string Definition = nameof(TestDataChildInstance.Definition);

    /// <summary>
    /// A constant string representing the result name of the test data.
    /// </summary>
    public const string Result = nameof(TestDataChildInstance.Result);

    /// <summary>
    /// A const string representing a non-null property used in tests.
    /// </summary>
    public const string NotNullProperty = "Test Property";

    /// <summary>
    /// A const instance of <see cref="DummyEnum"/> used in tests, initialized to <see cref="DummyEnum.TestValue"/>.
    /// </summary>
    public const DummyEnum DummyEnumTestValue = DummyEnum.TestValue;

    /// <summary>
    /// Represents a singleton instance of <see cref="DummyException"/> initialized with a constant
    /// string parameter. This instance is used for testing purposes to simulate exception handling
    /// scenarios with a predefined message.
    /// </summary>
    /// <param name="Parameter">The constant string parameter used to initialize the exception.</param>
    public static readonly DummyException DummyExceptionInstance = new(Parameter);

    /// <summary>
    /// Represents an invalid argument code. This is set to a value that is one greater than the highest
    /// value defined in the <see cref="ArgsCode"/> enumeration, ensuring it does not overlap with any
    /// valid argument codes. Useful for testing scenarios where invalid argument codes need to be handled.
    /// </summary>
    public static readonly ArgsCode InvalidArgsCode = (ArgsCode)Enum.GetNames<ArgsCode>().Length;
}
