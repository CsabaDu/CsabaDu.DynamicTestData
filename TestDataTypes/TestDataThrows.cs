namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract base class for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
public abstract class TestDataThrows<TException>
    : TestData, ITestDataThrows<TException>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected) : base(definition)
    => Expected = expected;

    public TException Expected { get; private set; }

    /// <summary>
    /// Gets the result name of the test case.
    /// </summary>
    public override sealed string Result => typeof(TException).Name;

    /// <summary>
    /// Gets the expected exit mode of the test, which is "throws" for this type.
    /// </summary>
    public override sealed string ExitMode => Throws;

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Expected);
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete class for test data that throws exceptions with one argument.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
public class TestDataThrows<TException, T1>
    : TestDataThrows<TException>, ITestData<TException, T1>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1)
        : base(definition, expected)
    => Arg1 = arg1;

    public T1? Arg1 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with two arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
public class TestDataThrows<TException, T1, T2>
    : TestDataThrows<TException, T1>, ITestData<TException, T1, T2>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2)
        : base(definition, expected, arg1)
    => Arg2 = arg2;

    public T2? Arg2 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with three arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
public class TestDataThrows<TException, T1, T2, T3>
    : TestDataThrows<TException, T1, T2>, ITestData<TException, T1, T2, T3>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3)
        : base(definition, expected, arg1, arg2)
    => Arg3 = arg3;

    public T3? Arg3 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with four arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4>
    : TestDataThrows<TException, T1, T2, T3>, ITestData<TException, T1, T2, T3, T4>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
        : base(definition, expected,arg1, arg2, arg3)
    => Arg4 = arg4;

    public T4? Arg4 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with five arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
/// <param name="arg5">The fifth argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4, T5>
    : TestDataThrows<TException, T1, T2, T3, T4>, ITestData<TException, T1, T2, T3, T4, T5>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
        : base(definition, expected, arg1, arg2, arg3, arg4)
    => Arg5 = arg5;

    public T5? Arg5 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with six arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
/// <param name="arg5">The fifth argument.</param>
/// <param name="arg6">The sixth argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4, T5, T6>
    : TestDataThrows<TException, T1, T2, T3, T4, T5>, ITestData<TException, T1, T2, T3, T4, T5, T6>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5)
    => Arg6 = arg6;

    public T6? Arg6 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with seven arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
/// <param name="arg5">The fifth argument.</param>
/// <param name="arg6">The sixth argument.</param>
/// <param name="arg7">The seventh argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6>, ITestData<TException, T1, T2, T3, T4, T5, T6, T7>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6)
    => Arg7 = arg7;

    public T7? Arg7 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with seven arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
/// <param name="arg5">The fifth argument.</param>
/// <param name="arg6">The sixth argument.</param>
/// <param name="arg7">The seventh argument.</param>
/// <param name="arg8">The eighth argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>, ITestData<TException, T1, T2, T3, T4, T5, T6, T7, T8>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
    => Arg8 = arg8;

    public T8? Arg8 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg8);
}

/// <summary>
/// Represents a concrete class for test data that throws exceptions with seven arguments.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
/// <param name="definition">The definition of the test data.</param>
/// <param name="expected">The expected exception of the test data.</param>
/// <param name="arg1">The first argument.</param>
/// <param name="arg2">The second argument.</param>
/// <param name="arg3">The third argument.</param>
/// <param name="arg4">The fourth argument.</param>
/// <param name="arg5">The fifth argument.</param>
/// <param name="arg6">The sixth argument.</param>
/// <param name="arg7">The seventh argument.</param>
/// <param name="arg8">The eighth argument.</param>
/// <param name="arg9">The ninth argument.</param>
public class TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>, ITestData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    where TException : Exception
{
    public TestDataThrows() : base() { }

    public TestDataThrows(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
        : base(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
    => Arg9 = arg9;

    public T9? Arg9 { get; private set; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion