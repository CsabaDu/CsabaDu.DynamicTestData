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
namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicTestCaseDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    #region TestDataToTestCaseData
    /// <summary>
    /// Converts test data to a TestCaseData instance.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1>(string definition, string expected, T1? arg1, string? testMethodName = null)
    => new TestData<T1>(definition, expected, arg1)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2, string? testMethodName = null)
    => new TestData<T1, T2>(definition, expected, arg1, arg2)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, string? testMethodName = null)
    => new TestData<T1, T2, T3>(definition, expected, arg1, arg2, arg3)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataToTestCaseData{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataToTestCaseData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9, string? testMethodName = null)
    => new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToTestCaseData(ArgsCode, testMethodName);
    #endregion

    #region TestDataReturnsToTestCaseData
    /// <summary>
    /// Converts test data to a TestCaseData instance for a test that expects a struct to assert.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a struct.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected struct of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1>(string definition, TStruct expected, T1? arg1, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1>(definition, expected, arg1)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, args6)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataReturnsToTestCaseData{TStruct, T1, T2, T3, T4, T5, T6, T7, t8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataReturnsToTestCaseData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9, string? testMethodName = null)
    where TStruct : struct
    => new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToTestCaseData(ArgsCode, testMethodName);
    #endregion

    #region TestDataThrowsToTestCaseData
    /// <summary>
    /// Converts test data to a TestCaseData for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test data.</param>
    /// <param name="expected">The expected exception of the test data.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1>(string definition, TException expected, T1? arg1, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1>(definition, expected, arg1)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3>(definition, expected, arg1, arg2, arg3)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToTestCaseData(ArgsCode, testMethodName);

    /// <inheritdoc cref="TestDataThrowsToTestCaseData{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>A TestCaseData instance.</returns>
    public TestCaseData TestDataThrowsToTestCaseData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9, string? testMethodName = null)
    where TException : Exception
    => new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToTestCaseData(ArgsCode, testMethodName);
    #endregion
}
