// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Statics;

/// <summary>
/// Provides factory methods for creating test data objects used in unit testing scenarios.
/// </summary>
/// <remarks>This class includes a variety of overloaded methods to create instances of test data objects with
/// different numbers of arguments. The methods are grouped into three categories: <list type="bullet"> <item>
/// <description><c>CreateTestData</c>: Creates test data with a string-based expected value.</description> </item>
/// <item> <description><c>CreateTestDataReturns</c>: Creates test data with a strongly-typed expected
/// value.</description> </item> <item> <description><c>CreateTestDataThrows</c>: Creates test data for scenarios where
/// an exception is expected.</description> </item> </list> These methods are designed to simplify the creation of test
/// cases by encapsulating the setup of test data.</remarks>
public static class TestDataFactory
{
    #region CreateTestData methods
    public static TestData<T1> CreateTestData<T1>(
        string definition,
        string expected,
        T1? arg1)
    => new(
        definition,
        expected,
        arg1);

    public static TestData<T1, T2> CreateTestData<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => new(
        definition,
        expected,
        arg1, arg2);

    public static TestData<T1, T2, T3> CreateTestData<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => new(
        definition,
        expected,
        arg1, arg2, arg3);

    public static TestData<T1, T2, T3, T4> CreateTestData<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4);

    public static TestData<T1, T2, T3, T4, T5> CreateTestData<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5);

    public static TestData<T1, T2, T3, T4, T5, T6> CreateTestData<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6);

    public static TestData<T1, T2, T3, T4, T5, T6, T7> CreateTestData<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static TestData<T1, T2, T3, T4, T5, T6, T7, T8> CreateTestData<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateTestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    #endregion

    #region CreateTestDataReturns methods
    public static TestDataReturns<TStruct, T1> CreateTestDataReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1);

    public static TestDataReturns<TStruct, T1, T2> CreateTestDataReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2);

    public static TestDataReturns<TStruct, T1, T2, T3> CreateTestDataReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3);

    public static TestDataReturns<TStruct, T1, T2, T3, T4> CreateTestDataReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4);

    public static TestDataReturns<TStruct, T1, T2, T3, T4, T5> CreateTestDataReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5);

    public static TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6> CreateTestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6);

    public static TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7> CreateTestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8> CreateTestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateTestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    #endregion

    #region CreateTestDataThrows methods
    public static TestDataThrows<TException, T1> CreateTestDataThrows<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1);

    public static TestDataThrows<TException, T1, T2> CreateTestDataThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2);

    public static TestDataThrows<TException, T1, T2, T3> CreateTestDataThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3);

    public static TestDataThrows<TException, T1, T2, T3, T4> CreateTestDataThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4);

    public static TestDataThrows<TException, T1, T2, T3, T4, T5> CreateTestDataThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5);

    public static TestDataThrows<TException, T1, T2, T3, T4, T5, T6> CreateTestDataThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6);

    public static TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7> CreateTestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8> CreateTestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateTestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => new(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    #endregion
}
