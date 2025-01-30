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
    /// A constant integer argument used in tests.
    /// </summary>
    public const int Arg1 = 1;

    /// <summary>
    /// A constant object argument used in tests, initialized to null.
    /// </summary>
    public const object Arg2 = null;

    /// <summary>
    /// A static readonly DateTime argument used in tests, initialized to DateTime.MinValue.
    /// </summary>
    public static readonly DateTime Arg3 = DateTime.MinValue;

    /// <summary>
    /// A constant string argument used in tests, initialized to the value of <see cref="Parameter"/>.
    /// </summary>
    public const string Arg4 = Parameter;

    /// <summary>
    /// A constant double argument used in tests, initialized to double.NegativeInfinity.
    /// </summary>
    public const double Arg5 = double.NegativeInfinity;

    /// <summary>
    /// A constant boolean argument used in tests, initialized to true.
    /// </summary>
    public const bool Arg6 = true;

    /// <summary>
    /// A constant char argument used in tests, initialized to 'a'.
    /// </summary>
    public const char Arg7 = 'a';

    /// <summary>
    /// A static readonly DummyClass argument used in tests, initialized to new instance.
    /// </summary>
    public static readonly DummyClass Arg8 = new();

    /// <summary>
    /// A static readonly array of objects used in tests, initialized to an empty array.
    /// </summary>
    public static readonly object[] Arg9 = [];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1.
    /// </summary>
    public static readonly object[] Args1 = [Arg1];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1 and Arg2.
    /// </summary>
    public static readonly object[] Args2 = [Arg1, Arg2];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, and Arg3.
    /// </summary>
    public static readonly object[] Args3 = [Arg1, Arg2, Arg3];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, and Arg4.
    /// </summary>
    public static readonly object[] Args4 = [Arg1, Arg2, Arg3, Arg4];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, and Arg5.
    /// </summary>
    public static readonly object[] Args5 = [Arg1, Arg2, Arg3, Arg4, Arg5];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, and Arg6.
    /// </summary>
    public static readonly object[] Args6 = [Arg1, Arg2, Arg3, Arg4, Arg5, Arg6];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, and Arg7.
    /// </summary>
    public static readonly object[] Args7 = [Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, and Arg8.
    /// </summary>
    public static readonly object[] Args8 = [Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8];

    /// <summary>
    /// A static readonly array of objects used in tests, initialized with Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, and Arg9.
    /// </summary>
    public static readonly object[] Args9 = [Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9];

    /// <summary>
    /// A static readonly instance of <see cref="TestDoubles.TestDataChild"/> used in tests, initialized with actual definition, result, and exit mode.
    /// </summary>
    public static readonly TestDataChild TestDataChild = new(ActualDefinition, ActualExitMode, ActualResult);

    /// <summary>
    /// A static readonly instance of <see cref="TestDataReturnsChild<DummyEnum>"/> used in tests, initialized with actual definition.
    /// </summary>
    public static readonly TestDataReturnsChild TestDataReturnsChild = new(ActualDefinition);

    /// <summary>
    /// Generates a test case string by combining the definition and exit mode result.
    /// </summary>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="exitModeResult">The exit mode result of the test case.</param>
    /// <returns>A string representing the test case in the format "definition => exitModeResult".</returns>
    public static string GetTestCase(string definition, string exitModeResult)
    => $"{definition} => {exitModeResult}";

    /// <summary>
    /// Generates an exit mode result string by combining the exit mode and result.
    /// </summary>
    /// <param name="exitMode">The exit mode of the test case.</param>
    /// <param name="result">The result of the test case.</param>
    /// <returns>A string representing the exit mode result in the format "exitMode result".</returns>
    public static string GetExitModeResult(string exitMode, string result)
    => $"{exitMode} {result}";

}
