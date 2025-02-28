﻿namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

/// <summary>
/// Base class containing methods to add test data to TheoryData.
/// </summary>
public abstract class DynamicTheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    protected TheoryData? TheoryData { get; set; }

    #region AddTestDataToTheoryData
    /// <summary>
    /// Adds test data to TheoryData for a single argument.
    /// </summary>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected result of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    public void AddTestDataToTheoryData<T1>(string definition, string expected, T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?>>();
                TestData<T1?> testData = new(definition, expected, arg1);
                (TheoryData as TheoryData<TestData<T1?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?>();
                (TheoryData as TheoryData<T1?>)!.Add(arg1);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?>>();
                TestData<T1?, T2?> testData = new(definition, expected, arg1, arg2);
                (TheoryData as TheoryData<TestData<T1?, T2?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?>();
                (TheoryData as TheoryData<T1?, T2?>)!.Add(arg1, arg2);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?>>();
                TestData<T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?>();
                (TheoryData as TheoryData<T1?, T2?, T3?>)!.Add(arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?>>();
                TestData<T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?>)!.Add(arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>>();
                TestData<T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?, T5?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?>)!.Add(arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>>();
                TestData<T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>();
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>();
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>();
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                (TheoryData as TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>();
                (TheoryData as TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }
    }
    #endregion

    #region AddTestDataReturnsToTheoryData
    /// <summary>
    /// Adds test data with expected return value to TheoryData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return value.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected return value of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?>>();
                TestDataReturns<TStruct, T1?> testData = new(definition, expected, arg1);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?>();
                (TheoryData as TheoryData<TStruct, T1?>)!.Add(expected, arg1);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?>>();
                TestDataReturns<TStruct, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?>)!.Add(expected, arg1, arg2);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?>)!.Add(expected, arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?>)!.Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>();
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                (TheoryData as TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>();
                (TheoryData as TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }
    }
    #endregion

    #region AddTestDataThrowsToTheoryData
    /// <summary>
    /// Adds test data with expected exception to TheoryData.
    /// </summary>
    /// <typeparam name="TException">The type of the expected exception.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected exception of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1>(string definition, TException expected, T1? arg1) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?>>();
                TestDataThrows<TException, T1?> testData = new(definition, expected, arg1);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?>();
                (TheoryData as TheoryData<TException, T1?>)!.Add(expected, arg1);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?>>();
                TestDataThrows<TException, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?>();
                (TheoryData as TheoryData<TException, T1?, T2?>)!.Add(expected, arg1, arg2);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?>>();
                TestDataThrows<TException, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?>)!.Add(expected, arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?>)!.Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?, T5?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TheoryData ??= new TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>();
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                (TheoryData as TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>>)!.Add(testData);
                break;
            case ArgsCode.Properties:
                TheoryData ??= new TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>();
                (TheoryData as TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>)!.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }
    }
    #endregion
}
