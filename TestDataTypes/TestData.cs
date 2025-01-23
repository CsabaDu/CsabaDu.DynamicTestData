namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract base record for test data.
/// </summary>
/// <typeparam name="TResult">The type of the result, which must be non-nullable.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
public abstract record TestData<TResult>(string Definition, string Result) : ITestData where TResult : notnull
{
    private readonly string NotNullResult = Result ?? string.Empty;

    /// <summary>
    /// Gets the exit mode based on the type name.
    /// </summary>
    private string ExitMode
    {
        get
        {
            const char GraveAccent = '`';
            string typeName = GetType().Name;
            int testDataNameLength = nameof(TestData<TResult>).Length;
            int graveAccentIndex = typeName.IndexOf(GraveAccent, testDataNameLength);

            return graveAccentIndex > -1 ?
                typeName[testDataNameLength..graveAccentIndex]
                : typeName[testDataNameLength..];
        }
    }

    /// <summary>
    /// Gets the test case string representation.
    /// </summary>
    public string TestCase => ExitMode == string.Empty ?
        $"{Definition} => {NotNullResult}"
        : $"{Definition} => {ExitMode} {NotNullResult}";

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="argsCode"/> is not valid.</exception>
    public virtual object?[] ToArgs(ArgsCode argsCode)
    {
        return argsCode switch
        {
            ArgsCode.Instance => [this],
            ArgsCode.Properties => [TestCase],
            _ => throw new InvalidEnumArgumentException(nameof(argsCode), (int)(object)argsCode, typeof(ArgsCode)),
        };
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override sealed string ToString() => TestCase;
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete record for test data with one argument.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
public record TestData<String, T1>(string Definition, string Result, T1? Arg1)
    : TestData<string>(Definition, Result), ITestData<String>
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg1) : base.ToArgs(argsCode);
}

/// <summary>
/// Represents a concrete record for test data with two arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
public record TestData<String, T1, T2>(string Definition, string Result, T1? Arg1, T2? Arg2)
    : TestData<string, T1>(Definition, Result, Arg1)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg2) : base.ToArgs(argsCode);
}

/// <summary>
/// Represents a concrete record for test data with three arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
public record TestData<String, T1, T2, T3>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestData<string, T1, T2>(Definition, Result, Arg1, Arg2)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg3) : base.ToArgs(argsCode);
}

/// <summary>
/// Represents a concrete record for test data with four arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
public record TestData<String, T1, T2, T3, T4>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestData<string, T1, T2, T3>(Definition, Result, Arg1, Arg2, Arg3)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg4) : base.ToArgs(argsCode);
}

/// <summary>
/// Represents a concrete record for test data with five arguments.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
public record TestData<String, T1, T2, T3, T4, T5>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestData<string, T1, T2, T3, T4>(Definition, Result, Arg1, Arg2, Arg3, Arg4)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg5) : base.ToArgs(argsCode);
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
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
public record TestData<String, T1, T2, T3, T4, T5, T6>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestData<string, T1, T2, T3, T4, T5>(Definition, Result, Arg1, Arg2, Arg3, Arg4, Arg5)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg6) : base.ToArgs(argsCode);
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
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Result">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
public record TestData<String, T1, T2, T3, T4, T5, T6, T7>(string Definition, string Result, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestData<string, T1, T2, T3, T4, T5, T6>(Definition, Result, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6)
{
    public override object?[] ToArgs(ArgsCode argsCode)
    => argsCode == ArgsCode.Properties ? base.ToArgs(argsCode).Append(Arg7) : base.ToArgs(argsCode);
}
#endregion