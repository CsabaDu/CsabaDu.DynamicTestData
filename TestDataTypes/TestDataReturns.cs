namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract record for test data returns with a specified structure type.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
public abstract record TestDataReturns<TStruct>(string Definition, TStruct Expected)
    : TestData<TStruct>(Definition, Expected.ToString()!), ITestDataReturns<TStruct>
    where TStruct : struct
{
    protected override sealed string ExitMode => "returns";

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Expected);
}
#endregion

#region Concrete types
/// <summary>
/// Represents a record for test data returns with one additional argument.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
public record TestDataReturns<TStruct, T1>(string Definition, TStruct Expected, T1? Arg1)
    : TestDataReturns<TStruct>(Definition, Expected)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <summary>
/// Represents a record for test data returns with two additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
public record TestDataReturns<TStruct, T1, T2>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2)
    : TestDataReturns<TStruct, T1>(Definition, Expected, Arg1)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <summary>
/// Represents a record for test data returns with three additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <typeparam name="T3">The type of the third additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
/// <param name="Arg3">The third additional argument.</param>
public record TestDataReturns<TStruct, T1, T2, T3>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestDataReturns<TStruct, T1, T2>(Definition, Expected, Arg1, Arg2)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <summary>
/// Represents a record for test data returns with four additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <typeparam name="T3">The type of the third additional argument.</typeparam>
/// <typeparam name="T4">The type of the fourth additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
/// <param name="Arg3">The third additional argument.</param>
/// <param name="Arg4">The fourth additional argument.</param>
public record TestDataReturns<TStruct, T1, T2, T3, T4>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestDataReturns<TStruct, T1, T2, T3>(Definition, Expected, Arg1, Arg2, Arg3)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <summary>
/// Represents a record for test data returns with five additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <typeparam name="T3">The type of the third additional argument.</typeparam>
/// <typeparam name="T4">The type of the fourth additional argument.</typeparam>
/// <typeparam name="T5">The type of the fifth additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
/// <param name="Arg3">The third additional argument.</param>
/// <param name="Arg4">The fourth additional argument.</param>
/// <param name="Arg5">The fifth additional argument.</param>
public record TestDataReturns<TStruct, T1, T2, T3, T4, T5>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestDataReturns<TStruct, T1, T2, T3, T4>(Definition, Expected, Arg1, Arg2, Arg3, Arg4)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <summary>
/// Represents a record for test data returns with six additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <typeparam name="T3">The type of the third additional argument.</typeparam>
/// <typeparam name="T4">The type of the fourth additional argument.</typeparam>
/// <typeparam name="T5">The type of the fifth additional argument.</typeparam>
/// <typeparam name="T6">The type of the sixth additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
/// <param name="Arg3">The third additional argument.</param>
/// <param name="Arg4">The fourth additional argument.</param>
/// <param name="Arg5">The fifth additional argument.</param>
/// <param name="Arg6">The sixth additional argument.</param>
public record TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <summary>
/// Represents a record for test data returns with seven additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first additional argument.</typeparam>
/// <typeparam name="T2">The type of the second additional argument.</typeparam>
/// <typeparam name="T3">The type of the third additional argument.</typeparam>
/// <typeparam name="T4">The type of the fourth additional argument.</typeparam>
/// <typeparam name="T5">The type of the fifth additional argument.</typeparam>
/// <typeparam name="T6">The type of the sixth additional argument.</typeparam>
/// <typeparam name="T7">The type of the seventh additional argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first additional argument.</param>
/// <param name="Arg2">The second additional argument.</param>
/// <param name="Arg3">The third additional argument.</param>
/// <param name="Arg4">The fourth additional argument.</param>
/// <param name="Arg5">The fifth additional argument.</param>
/// <param name="Arg6">The sixth additional argument.</param>
/// <param name="Arg7">The seventh additional argument.</param>
public record TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(string Definition, TStruct Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6)
    where TStruct : struct
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}
#endregion