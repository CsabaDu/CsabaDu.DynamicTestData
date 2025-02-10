using System.Text.Json;

namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract record for test data.
/// </summary>
public abstract class TestData : ITestData
{
    public TestData() { }

    /// <param name="definition">The definition of the test data.</param>
    public TestData(string definition)
    => Definition = definition;

    public string Definition { get; } = string.Empty;
    /// <summary>
    /// Represents the "returns" exit mode of the test case.
    /// </summary>
    internal const string Returns = "returns";

    /// <summary>
    /// Represents the "throws" exit mode of the test case.
    /// </summary>
    internal const string Throws = "throws";

    /// <summary>
    /// Gets the definition of the test case, ensuring it is not null.
    /// </summary>
    private string NotNullDefinition => string.IsNullOrEmpty(Definition) ? nameof(Definition) : Definition;

    /// <summary>
    /// Gets the result name of the test case, ensuring it is not null.
    /// </summary>
    private string NotNullResult => string.IsNullOrEmpty(Result) ? nameof(Result) : Result;

    /// <summary>
    /// Gets the result name of the test case, default value is an empty string.
    /// </summary>
    public virtual string Result { get; } = string.Empty;

    /// <summary>
    /// Gets the test case string representation.
    /// </summary>
    public string TestCase => string.IsNullOrEmpty(ExitMode) ?
        $"{NotNullDefinition} => {NotNullResult}"
        : $"{NotNullDefinition} => {ExitMode} {NotNullResult}";

    /// <summary>
    /// Gets the result name of the test case.
    /// </summary>
    /// <summary>
    /// Gets the expected exit mode of the test case, default value is an empty string.
    /// </summary>
    public virtual string ExitMode { get; } = string.Empty;

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="argsCode"/> is not valid.</exception>
    public virtual object?[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        ArgsCode.Properties => [TestCase],
        _ => throw new InvalidEnumArgumentException(nameof(argsCode), (int)(object)argsCode, typeof(ArgsCode)),
    };

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>The test case string representation.</returns>
    public override sealed string ToString() => TestCase;

    public string Serialize()
    => JsonSerializer.Serialize(this, GetType(), new JsonSerializerOptions { WriteIndented = true });

    public static TTestData? Deserialize<TTestData>(string json) where TTestData : TestData
    => JsonSerializer.Deserialize<TTestData>(json);
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete record for test data with one argument.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
public class TestData<T1> : TestData, ITestData<string, T1>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    public TestData(string definition, string expected, T1? arg1) 
        : base(definition)
    {
        Expected = expected;
        Arg1 = arg1;
    }

    public string Expected { get; } = string.Empty;

    public T1? Arg1 { get; }

    /// <summary>
    /// Gets the name of the expected result description of the test case.
    /// </summary>
    public override string Result => Expected;

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <summary>
/// Represents a concrete record for test data with two arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
public class TestData<T1, T2> : TestData<T1>, ITestData<string, T1, T2>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2)
        : base(definition, expected, arg1)
    => Arg2 = arg2;

    public T2? Arg2 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <summary>
/// Represents a concrete record for test data with three arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
public class TestData<T1, T2, T3> : TestData<T1, T2>, ITestData<string, T1, T2, T3>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
        : base(definition, expected, arg1, arg2)
    => Arg3 = arg3;

    public T3? Arg3 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <summary>
/// Represents a concrete record for test data with four arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="arg4">The fourth argument.</param>
public class TestData<T1, T2, T3, T4> : TestData<T1, T2, T3>, ITestData<string, T1, T2, T3, T4>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
        : base(definition, expected, arg1, arg2, arg3)
    => Arg4 = arg4;

    public T4? Arg4 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <summary>
/// Represents a concrete record for test data with five arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="arg5">The fifth argument.</param>
public class TestData<T1, T2, T3, T4, T5> : TestData<T1, T2, T3, T4>, ITestData<string, T1, T2, T3, T4, T5>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
        : base(definition, expected, arg1, arg2, arg3, arg4)
    => Arg5 = arg5;

    public T5? Arg5 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <summary>
/// Represents a concrete record for test data with six arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
public class TestData<T1, T2, T3, T4, T5, T6> : TestData<T1, T2, T3, T4, T5>, ITestData<string, T1, T2, T3, T4, T5, T6>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5)
    => Arg6 = arg6;

    public T6? Arg6 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <summary>
/// Represents a concrete record for test data with seven arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
public class TestData<T1, T2, T3, T4, T5, T6, T7> : TestData<T1, T2, T3, T4, T5, T6>, ITestData<string, T1, T2, T3, T4, T5, T6, T7>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6)
    => Arg7 = arg7;

    public T7? Arg7 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}

/// <summary>
/// Represents a concrete record for test data with seven arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="arg8">The eighth argument.</param>
public class TestData<T1, T2, T3, T4, T5, T6, T7, T8> : TestData<T1, T2, T3, T4, T5, T6, T7>, ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
    => Arg8 = arg8;

    public T8? Arg8 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg8);
}

/// <summary>
/// Represents a concrete record for test data with seven arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
public class TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9> : TestData<T1, T2, T3, T4, T5, T6, T7, T8>, ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    public TestData() : base() { }

    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The result of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    public TestData(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
    => Arg9 = arg9;

    public T9? Arg9 { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion