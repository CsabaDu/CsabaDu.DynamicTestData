namespace CsabaDu.DynamicTestData.Tests.TestParameters;

/// <summary>
/// Provides a set of constant and const parameters for testing purposes.
/// </summary>
internal sealed class Params
{
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
    /// A const string representing the name of the Expected propety of a TestCase type used in tests.
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
    /// A const instance of <see cref="DummyEnumTestValue"/> used in tests, initialized to <see cref="DummyEnum.TestValue"/>.
    /// </summary>
    public const DummyEnum DummyEnumTestValue = DummyEnum.TestValue;

    public static readonly DummyException DummyExceptionInstance = new(Parameter);

    public static readonly ArgsCode InvalidArgsCode = (ArgsCode)Enum.GetNames<ArgsCode>().Length;

    /// <summary>
    /// A const instance of <see cref="TestDoubles.TestDataChild"/> used in tests, initialized with actual definition, result, and exit mode.
    /// </summary>
    public static readonly TestDataChild TestDataChildInstance
        = new(ActualDefinition, null, ExpectedString);

    /// <summary>
    /// A const instance of <see cref="TestDataReturnsChildInstance<DummyEnum>"/> used in tests, initialized with actual definition.
    /// </summary>
    public static readonly TestDataReturnsChild<DummyEnum> TestDataReturnsChildInstance
        = new(ActualDefinition, DummyEnumTestValue);

    /// <summary>
    /// A const instance of <see cref="TestDataThrowsChildInstance"/> used in tests, initialized with actual definition, parameter, and error message.
    /// </summary>
    public static readonly TestDataThrowsChild<DummyException> TestDataThrowsChildInstance
        = new(ActualDefinition, DummyExceptionInstance/*, Parameter, ErrorMessage*/);

    /// <summary>
    /// Generates a test case string by combining the definition and exit mode result.
    /// </summary>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="exitModeResult">The exit mode result of the test case.</param>
    /// <returns>A string representing the test case in the format "definition => exitModeResult".</returns>
    public static string GetTestDataTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    /// <summary>
    /// Generates an exit mode result string by combining the exit mode and result.
    /// </summary>
    /// <param name="exitMode">The exit mode of the test case.</param>
    /// <param name="result">The result of the test case.</param>
    /// <returns>A string representing the exit mode result in the format "exitMode result".</returns>
    public static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

    /// <summary>
    /// Gets a test case string by combining the actual definition and expected string.
    /// </summary>
    public static string TestDataTestCase
    => GetTestDataTestCase(ActualDefinition, ExpectedString);

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data returns.
    /// </summary>
    public static string TestDataReturnsTestCase
    => GetTestDataTestCase(ActualDefinition, GetExitModeResult(TestData.Returns, DummyEnumTestValue.ToString()));

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data throws.
    /// </summary>
    public static string TestDataThrowsTestCase
    => GetTestDataTestCase(ActualDefinition, GetExitModeResult(TestData.Throws, typeof(DummyException).Name));
}
