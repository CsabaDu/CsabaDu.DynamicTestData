namespace CsabaDu.DynamicTestData.Tests.TestHelpers;

/// <summary>
/// Provides a set of constant and static readonly parameters for testing purposes.
/// </summary>
internal sealed class Params
{
    /// <summary>
    /// A constant string parameter.
    /// </summary>
    public const string Parameter = "parameter";

    /// <summary>
    /// A static readonly string representing the actual definition used in tests.
    /// </summary>
    public static readonly string ActualDefinition = "Test Definition";

    /// <summary>
    /// A static readonly string representing the expected string used in tests.
    /// </summary>
    public static readonly string ExpectedString = "Test Expected";

    /// <summary>
    /// A static readonly string representing the actual result used in tests.
    /// </summary>
    public static readonly string ActualResult = "Test Result";

    /// <summary>
    /// A static readonly string representing the actual exit mode used in tests.
    /// </summary>
    public static readonly string ActualExitMode = "Test Exit Mode";

    /// <summary>
    /// A constant string representing the definition name of the test data.
    /// </summary>
    public const string Definition = nameof(TestDataChild.Definition);

    /// <summary>
    /// A constant string representing the result name of the test data.
    /// </summary>
    public const string Result = nameof(TestDataChild.Result);

    /// <summary>
    /// A static readonly string representing a non-null property used in tests.
    /// </summary>
    public static readonly string NotNullProperty = "Test Property";

    /// <summary>
    /// A static readonly instance of <see cref="DummyEnumTestValue"/> used in tests, initialized to <see cref="DummyEnum.TestValue"/>.
    /// </summary>
    public static readonly DummyEnum DummyEnumTestValue = DummyEnum.TestValue;

    /// <summary>
    /// A constant string representing the error message used in tests.
    /// </summary>
    public const string ErrorMessage = "Test error message";

    /// <summary>
    /// A static readonly instance of <see cref="TestDoubles.TestDataChild"/> used in tests, initialized with actual definition, result, and exit mode.
    /// </summary>
    public static readonly TestDataChild TestDataChild = new(ActualDefinition, ActualExitMode, ActualResult);

    /// <summary>
    /// A static readonly instance of <see cref="TestDataReturnsChild<DummyEnum>"/> used in tests, initialized with actual definition.
    /// </summary>
    public static readonly TestDataReturnsChild TestDataReturnsChild = new(ActualDefinition);

    /// <summary>
    /// A static readonly instance of <see cref="TestDataThrowsChild"/> used in tests, initialized with actual definition, parameter, and error message.
    /// </summary>
    public static readonly TestDataThrowsChild TestDataThrowsChild = new(ActualDefinition, Parameter, ErrorMessage);

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

}
