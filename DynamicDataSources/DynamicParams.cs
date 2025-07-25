﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Represents a dynamic parameter configuration for test data sources,  supporting the generation of test arguments and
/// expected results.
/// </summary>
/// <remarks>This class provides methods to convert test data definitions into arrays of arguments  for various
/// test scenarios, including those with expected results, struct assertions,  or expected exceptions. It implements
/// <see cref="IDataStrategy"/> to ensure compatibility  with data-driven testing strategies.</remarks>
/// <param name="argsCode"></param>
/// <param name="withExpected"></param>
public class DynamicParams(ArgsCode argsCode, bool? withExpected)
: DynamicDataSource(argsCode),
IDataStrategy
{
    #region Properties
    public bool? WithExpected { get; init; } = withExpected;
    #endregion

    #region Methods
    #region Equals
    public bool Equals(IDataStrategy? other)
    => other is not null
        && ArgsCode == other.ArgsCode
        && WithExpected == other.WithExpected;

    public override bool Equals(object? obj)
    => obj is IDataStrategy other
        && Equals(other);
    #endregion

    #region GetHashCode
    public override int GetHashCode()
    => HashCode.Combine(
        ArgsCode,
        WithExpected);
    #endregion

    #region TestDataToParams
    /// <summary>
    /// Converts test testDataRows to an array of arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test testDataRows.</param>
    /// <param name="expected">The expected result of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1>(
        string definition,
        string expected,
        T1? arg1)
    => CreateTestData(
        definition,
        expected,
        arg1)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataToParams{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataToParams<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToParams(ArgsCode, WithExpected);
    #endregion

    #region TestDataReturnsToParams
    /// <summary>
    /// Converts test testDataRows to an array of arguments for a test that expects a struct to assert.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected result, which must be a not null <see cref="ValueType"/> object.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test testDataRows.</param>
    /// <param name="expected">The expected struct of the test.</param>
    /// <param name="arg1">The first argument.</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="ArgsCode"/> property has an invalid value.</exception>
    /// <returns>
    /// An array of arguments to be used in a test that expects an not nullable
    /// <see cref="ValueType" /> object of type <typeparamref name="TStruct"/>.
    /// </returns>
    public object?[] TestDataReturnsToParams<TStruct, T1>(
        string definition,
        TStruct expected, 
        T1? arg1)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>An array of arguments.</returns>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? args6)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, args6)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataReturnsToParams{TStruct, T1, T2, T3, T4, T5, T6, T7, t8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    public object?[] TestDataReturnsToParams<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToParams(ArgsCode, WithExpected);
    #endregion

    #region TestDataThrowsToParams
    /// <summary>
    /// Converts test testDataRows to an array of arguments for a test that throws an exception.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that is expected to be thrown.</typeparam>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">The definition of the test testDataRows.</param>
    /// <param name="expected">The expected exception of the test testDataRows.</param>
    /// <param name="arg1">The first argument.</param>
    /// <exception cref="InvalidOperationException">Thrown when the <see cref="ArgsCode"/> property has an invalid value.</exception>
    /// <returns>
    /// An array of arguments to be used in a test that expects
    /// an exception of type <typeparamref name="TException"/>.
    /// </returns>
    public object?[] TestDataThrowsToParams<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        .ToParams(ArgsCode, WithExpected);

    /// <inheritdoc cref="TestDataThrowsToParams{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument.</param>
    public object?[] TestDataThrowsToParams<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        .ToParams(ArgsCode, WithExpected);
    #endregion
    #endregion
}
