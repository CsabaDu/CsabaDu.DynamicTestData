namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract base record for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
public abstract record TestDataThrows<TException>(string Definition, string ParamName, string Message)
    : TestData<TException>(Definition, typeof(TException).Name), ITestDataThrows<TException>
    where TException : Exception
{
    protected override sealed string ExitMode => "throws";

    /// <summary>
    /// Gets the type of the exception.
    /// </summary>
    public Type ExceptionType => typeof(TException);

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => argsCode == ArgsCode.Properties ?
        [.. base.ToArgs(argsCode), ParamName, Message, ExceptionType]
        : base.ToArgs(argsCode);
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete record for test data that throws exceptions with one argument.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
public record TestDataThrows<TException, T1>(string Definition, string ParamName, string Message, T1? Arg1)
    : TestDataThrows<TException>(Definition, ParamName, Message)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with two arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
public record TestDataThrows<TException, T1, T2>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2)
    : TestDataThrows<TException, T1>(Definition, ParamName, Message, Arg1)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with three arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
public record TestDataThrows<TException, T1, T2, T3>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestDataThrows<TException, T1, T2>(Definition, ParamName, Message, Arg1, Arg2)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with four arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestDataThrows<TException, T1, T2, T3>(Definition, ParamName, Message, Arg1, Arg2, Arg3)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with five arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestDataThrows<TException, T1, T2, T3, T4>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with six arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestDataThrows<TException, T1, T2, T3, T4, T5>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4, Arg5)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <summary>
/// Represents a concrete record for test data that throws exceptions with seven arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="ParamName">The name of the parameter that causes the exception.</param>
/// <param name="Message">The message associated with the exception.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(string Definition, string ParamName, string Message, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(Definition, ParamName, Message, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6)
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}
#endregion