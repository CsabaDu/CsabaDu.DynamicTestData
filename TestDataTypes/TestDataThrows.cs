/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace CsabaDu.DynamicTestData.TestDataTypes;

#region Abstract type
/// <summary>
/// Represents an abstract base record for test data that throws exceptions.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception of the test data.</param>
public abstract record TestDataThrows<TException>(string Definition, TException Expected)
    : TestData(Definition), ITestDataThrows<TException>
    where TException : Exception
{
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
/// Represents a concrete record for test data that throws exceptions with one argument.
/// </summary>
/// <typeparam name="TException">The type of the exception, which must be derived from <see cref="Exception"/>.</typeparam>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
public record TestDataThrows<TException, T1>(string Definition, TException Expected, T1? Arg1)
    : TestDataThrows<TException>(Definition, Expected), ITestData<TException, T1>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
public record TestDataThrows<TException, T1, T2>(string Definition, TException Expected, T1? Arg1, T2? Arg2)
    : TestDataThrows<TException, T1>(Definition, Expected, Arg1), ITestData<TException, T1, T2>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
public record TestDataThrows<TException, T1, T2, T3>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestDataThrows<TException, T1, T2>(Definition, Expected, Arg1, Arg2), ITestData<TException, T1, T2, T3>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestDataThrows<TException, T1, T2, T3>(Definition, Expected, Arg1, Arg2, Arg3), ITestData<TException, T1, T2, T3, T4>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestDataThrows<TException, T1, T2, T3, T4>(Definition, Expected, Arg1, Arg2, Arg3, Arg4), ITestData<TException, T1, T2, T3, T4, T5>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestDataThrows<TException, T1, T2, T3, T4, T5>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5), ITestData<TException, T1, T2, T3, T4, T5, T6>
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
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), ITestData<TException, T1, T2, T3, T4, T5, T6, T7>
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
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
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
/// <param name="Arg8">The eighth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8)
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), ITestData<TException, T1, T2, T3, T4, T5, T6, T7, T8>
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg8);
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
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The expected exception of the test data.</param>
/// <param name="Arg1">The first argument.</param>
/// <param name="Arg2">The second argument.</param>
/// <param name="Arg3">The third argument.</param>
/// <param name="Arg4">The fourth argument.</param>
/// <param name="Arg5">The fifth argument.</param>
/// <param name="Arg6">The sixth argument.</param>
/// <param name="Arg7">The seventh argument.</param>
/// <param name="Arg8">The eighth argument.</param>
/// <param name="Arg9">The ninth argument.</param>
public record TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string Definition, TException Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8, T9? Arg9)
    : TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), ITestData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    where TException : Exception
{
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments.</returns>
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion