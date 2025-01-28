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
    public const string Definition = nameof(TestData.Definition);

    /// <summary>
    /// A constant string representing the result name of the test data.
    /// </summary>
    public const string Result = nameof(TestData.Result);

    /// <summary>
    /// A static readonly string representing a non-null property used in tests.
    /// </summary>
    public static readonly string NotNullProperty = "Test Property";

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
    /// A constant float argument used in tests, initialized to float.MaxValue.
    /// </summary>
    public const float Arg8 = float.MaxValue;

    /// <summary>
    /// A static readonly array of objects used in tests, initialized to an empty array.
    /// </summary>
    public static readonly object[] Arg9 = [];

    /// <summary>
    /// A static readonly instance of <see cref="TestDataChild"/> used in tests, initialized with actual definition, result, and exit mode.
    /// </summary>
    public static readonly TestDataChild TestData = new(ActualDefinition, ActualExitMode, ActualResult);
}
