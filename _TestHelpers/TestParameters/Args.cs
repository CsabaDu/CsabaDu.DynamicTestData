namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public static class Args
{
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
}
