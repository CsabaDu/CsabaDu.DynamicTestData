namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract class for test data returns with a specified structure type.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
public abstract class TestDataReturns<TStruct>
    : TestData, ITestDataReturns<TStruct>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected) : base(definition)
    => Expected = expected;

    public TStruct Expected { get; private set; }

    /// <summary>
    /// Gets the expected exit mode of the test, which is "returns" for this type.
    /// </summary>
    public override sealed string ExitMode => Returns;

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Expected);

    /// <summary>
    /// Gets the name of the expected result struct of the test case, ensuring it is not null.
    /// </summary>
    public override sealed string Result => Expected.ToString() ?? string.Empty;
}
#endregion

#region Concrete types
/// <summary>
/// Represents a class for test data returns with one additional argument.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="arg1">The first argument.</param>
public class TestDataReturns<TStruct, T1>
    : TestDataReturns<TStruct>, ITestData<TStruct, T1>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1)
        : base(definition, expected)
    => Arg1 = arg1;

    public T1? Arg1 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <summary>
/// Represents a class for test data returns with two additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
public class TestDataReturns<TStruct, T1, T2>
    : TestDataReturns<TStruct, T1>, ITestData<TStruct, T1, T2>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2)
        : base(definition, expected, arg1)
    => Arg2 = arg2;

    public T2? Arg2 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <summary>
/// Represents a class for test data returns with three additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3>
    : TestDataReturns<TStruct, T1, T2>, ITestData<TStruct, T1, T2, T3>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3)
        : base(definition, expected, arg1, arg2)
    => Arg3 = arg3;

    public T3? Arg3 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <summary>
/// Represents a class for test data returns with four additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4>
    : TestDataReturns<TStruct, T1, T2, T3>, ITestData<TStruct, T1, T2, T3, T4>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
        : base(definition, expected, arg1, arg2, arg3)
    => Arg4 = arg4;

    public T4? Arg4 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <summary>
/// Represents a class for test data returns with five additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4, T5>
    : TestDataReturns<TStruct, T1, T2, T3, T4>, ITestData<TStruct, T1, T2, T3, T4, T5>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
        : base(definition, expected, arg1, arg2, arg3, arg4)
    => Arg5 = arg5;

    public T5? Arg5 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <summary>
/// Represents a class for test data returns with six additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5>, ITestData<TStruct, T1, T2, T3, T4, T5, T6>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5)
    => Arg6 = arg6;

    public T6? Arg6 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <summary>
/// Represents a class for test data returns with seven additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>, ITestData<TStruct, T1, T2, T3, T4, T5, T6, T7>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6)
    => Arg7 = arg7;

    public T7? Arg7 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}

/// <summary>
/// Represents a class for test data returns with seven additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
/// <param name="Arg8">The eighth argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>, ITestData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
    => Arg8 = arg8;

    public T8? Arg8 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg8);
}

/// <summary>
/// Represents a class for test data returns with seven additional arguments.
/// </summary>
/// <typeparam name="TStruct">The type of the expected return value, which must be a struct.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
/// <param name="gefinition">The definition of the test data.</param>
/// <param name="expected">The expected return value of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
/// <param name="Arg8">The eighth argument.</param>
/// <param name="Arg9">The ninth argument.</param>
public class TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    : TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>, ITestData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    where TStruct : struct
{
    public TestDataReturns() : base() { }

    public TestDataReturns(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
    => Arg9 = arg9;

    public T9? Arg9 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified argument code.
    /// </summary>
    /// <param name="argsCode">The code indicating which arguments to include.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion
