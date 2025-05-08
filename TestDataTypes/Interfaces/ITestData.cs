// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

/// <summary>
/// Represents a test data interface with properties for test case and result, and a method to convert arguments.
/// </summary>
public interface ITestData
{
    /// <summary>
    /// Gets the definition of the test case.
    /// </summary>
    string Definition { get; }

    /// <summary>
    /// Gets the expected exit mode of the test.
    /// </summary>
    string? ExitMode { get; }

    /// <summary>
    /// Gets the name of the expected result of the test case.
    /// </summary>
    string Result { get; }
 
    /// <summary>
    /// Gets the test case description.
    /// </summary>
    string TestCase { get; }

    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the arguments.</param>
    /// <returns>An array of arguments.</returns>
    object?[] ToArgs(ArgsCode argsCode);
}

/// <summary>
/// Represents a generic test data interface that extends <see cref="ITestData"/>.
/// </summary>
/// <typeparam name="TResult">The type of the expected result of the test.</typeparam>
public interface ITestData<out TResult>
: ITestData
where TResult : notnull
{
    /// <summary>
    /// Gets the expected result of the test case.
    /// </summary>
    TResult Expected { get; }
}

/// <inheritdoc cref="ITestData{TResult}" />
/// <typeparam name="T1">The first type of the test data.</typeparam>
public interface ITestData<out TResult, out T1>
: ITestData<TResult>
where TResult : notnull
{
    /// <summary>
    /// Gets the first argument of the test case.
    /// </summary>
    T1? Arg1 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1}" />
/// <typeparam name="T2">The second type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2>
: ITestData<TResult, T1>
where TResult : notnull
{
    /// <summary>
    /// Gets the second argument of the test case.
    /// </summary>
    T2? Arg2 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2}" />
/// <typeparam name="T3">The third type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3>
: ITestData<TResult, T1, T2>
where TResult : notnull
{
    /// <summary>
    /// Gets the third argument of the test case.
    /// </summary>
    T3? Arg3 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3}" />
/// <typeparam name="T4">The fourth type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4>
: ITestData<TResult, T1, T2, T3>
where TResult : notnull
{
    /// <summary>
    /// Gets the fourth argument of the test case.
    /// </summary>
    T4? Arg4 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3, T4}" />
/// <typeparam name="T5">The fifth type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4, out T5>
: ITestData<TResult, T1, T2, T3, T4>
where TResult : notnull
{
    /// <summary>
    /// Gets the fifth argument of the test case.
    /// </summary>
    T5? Arg5 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3, T4, T5}" />
/// <typeparam name="T6">The sixth type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4, out T5, out T6>
: ITestData<TResult, T1, T2, T3, T4, T5>
where TResult : notnull
{
    /// <summary>
    /// Gets the sixth argument of the test case.
    /// </summary>
    T6? Arg6 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3, T4, T5, T6}" />
/// <typeparam name="T7">The seventh type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4, out T5, out T6, out T7>
: ITestData<TResult, T1, T2, T3, T4, T5, T6>
where TResult : notnull
{
    /// <summary>
    /// Gets the seventh argument of the test case.
    /// </summary>
    T7? Arg7 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3, T4, T5, T6, T7}" />
/// <typeparam name="T8">The eighth type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8>
: ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>
where TResult : notnull
{
    /// <summary>
    /// Gets the eighth argument of the test case.
    /// </summary>
    T8? Arg8 { get; }
}

/// <inheritdoc cref="ITestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8}" />
/// <typeparam name="T9">The ninth type of the test data.</typeparam>
public interface ITestData<out TResult, out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9>
: ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> where TResult : notnull
{
    /// <summary>
    /// Gets the ninth argument of the test case.
    /// </summary>
    T9? Arg9 { get; }
}
