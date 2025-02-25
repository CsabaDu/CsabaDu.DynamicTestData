namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public sealed class TestDataChildren
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
    => TestDataChildInstance.TestCase;

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data returns.
    /// </summary>
    public static string TestDataReturnsTestCase
    => TestDataReturnsChildInstance.TestCase;

    /// <summary>
    /// Gets a test case string by combining the actual definition and the exit mode result of the test data throws.
    /// </summary>
    public static string TestDataThrowsTestCase
    => TestDataThrowsChildInstance.TestCase;
}
