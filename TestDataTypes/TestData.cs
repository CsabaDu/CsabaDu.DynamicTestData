﻿/* 
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
/// Represents an abstract record for test data.
/// </summary>
/// <param name="Definition">The definition of the test data.</param>
public abstract record TestData(string Definition) : ITestData
{
    #region Constants
    /// <summary>
    /// Represents the "returns" exit mode of the test case.
    /// </summary>
    internal const string Returns = "returns";

    /// <summary>
    /// Represents the "throws" exit mode of the test case.
    /// </summary>
    internal const string Throws = "throws";
    #endregion

    #region Properties
    /// <summary>
    /// Gets the definition of the test case, ensuring it is not null.
    /// </summary>
    private string NotNullDefinition => string.IsNullOrEmpty(Definition) ? nameof(Definition) : Definition;

    /// <summary>
    /// Gets the result name of the test case, ensuring it is not null.
    /// </summary>
    private string NotNullResult => string.IsNullOrEmpty(Result) ? nameof(Result) : Result;

    /// <summary>
    /// Gets the result name of the test case, default value is the name of the property.
    /// </summary>
    public virtual string Result { get; } = nameof(Result);

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
    #endregion

    #region Methods
    /// <summary>
    /// Converts the test data to an array of arguments based on the specified <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The code indicating how to convert the test data to arguments.</param>
    /// <returns>An array of arguments, containing
    /// - This instance if <paramref name="argsCode"/> value is <enum cref="ArgsCode.Instance" />,
    /// - The defined properties of this instance if <paramref name="argsCode"/> value is <enum cref="ArgsCode.Properties" />
    /// .</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="argsCode"/> is not valid.</exception>
    public virtual object?[] ToArgs(ArgsCode argsCode) => argsCode switch
    {
        ArgsCode.Instance => [this],
        ArgsCode.Properties => [TestCase],
        _ => throw argsCode.GetInvalidEnumArgumentException(nameof(argsCode)),
    };

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>The test case string representation.</returns>
    public override sealed string ToString() => TestCase;
    #endregion
}
#endregion

#region Concrete types
/// <summary>
/// Represents a concrete record for test data with one argument.
/// </summary>
/// <typeparam name="T1">The type of the first argument.</typeparam>
/// <param name="Definition">The definition of the test data.</param>
/// <param name="Expected">The result of the test data.</param>
/// <param name="Arg1">The first argument.</param>
public record TestData<T1>(string Definition, string Expected, T1? Arg1)
    : TestData(Definition), ITestData<string, T1>
{
    /// <summary>
    /// Gets the name of the expected result description of the test case, default value is the name of the Expected property.
    /// </summary>
    public override string Result => string.IsNullOrEmpty(Expected) ? nameof(Expected) : Expected;

    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg1);
}

/// <inheritdoc cref="TestData{T1}" />
/// <typeparam name="T2">The type of the second argument.</typeparam>
/// <param name="Arg2">The second argument.</param>
public record TestData<T1, T2>(string Definition, string Expected, T1? Arg1, T2? Arg2)
    : TestData<T1>(Definition, Expected, Arg1), ITestData<string, T1, T2>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg2);
}

/// <inheritdoc cref="TestData{T1, T2}" />
/// <typeparam name="T3">The type of the third argument.</typeparam>
/// <param name="Arg3">The third argument.</param>
public record TestData<T1, T2, T3>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3)
    : TestData<T1, T2>(Definition, Expected, Arg1, Arg2), ITestData<string, T1, T2, T3>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg3);
}

/// <inheritdoc cref="TestData{T1, T2, T3}" />
/// <typeparam name="T4">The type of the fourth argument.</typeparam>
/// <param name="Arg4">The fourth argument.</param>
public record TestData<T1, T2, T3, T4>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4)
    : TestData<T1, T2, T3>(Definition, Expected, Arg1, Arg2, Arg3), ITestData<string, T1, T2, T3, T4>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg4);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4}" />
/// <typeparam name="T5">The type of the fifth argument.</typeparam>
/// <param name="Arg5">The fifth argument.</param>
public record TestData<T1, T2, T3, T4, T5>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5)
    : TestData<T1, T2, T3, T4>(Definition, Expected, Arg1, Arg2, Arg3, Arg4), ITestData<string, T1, T2, T3, T4, T5>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg5);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5}" />
/// <typeparam name="T6">The type of the sixth argument.</typeparam>
/// <param name="Arg6">The sixth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6)
    : TestData<T1, T2, T3, T4, T5>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5), ITestData<string, T1, T2, T3, T4, T5, T6>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg6);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6}" />
/// <typeparam name="T7">The type of the seventh argument.</typeparam>
/// <param name="Arg7">The seventh argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7)
    : TestData<T1, T2, T3, T4, T5, T6>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), ITestData<string, T1, T2, T3, T4, T5, T6, T7>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg7);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6, T7}" />
/// <typeparam name="T8">The type of the eighth argument.</typeparam>
/// <param name="Arg8">The eighth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7, T8>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8)
    : TestData<T1, T2, T3, T4, T5, T6, T7>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg8);
}

/// <inheritdoc cref="TestData{T1, T2, T3, T4, T5, T6, T7, T8}" />
/// <typeparam name="T9">The type of the ninth argument.</typeparam>
/// <param name="Arg9">The ninth argument.</param>
public record TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string Definition, string Expected, T1? Arg1, T2? Arg2, T3? Arg3, T4? Arg4, T5? Arg5, T6? Arg6, T7? Arg7, T8? Arg8, T9? Arg9)
    : TestData<T1, T2, T3, T4, T5, T6, T7, T8>(Definition, Expected, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), ITestData<string, T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    /// <inheritdoc cref="TestData.ToArgs(ArgsCode)" />
    public override object?[] ToArgs(ArgsCode argsCode) => base.ToArgs(argsCode).Add(argsCode, Arg9);
}
#endregion
