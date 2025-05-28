// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

/// <summary>
/// Base class containing methods to add test _data to TheoryData.
/// </summary>
public abstract class DynamicTheoryDataSource(ArgsCode argsCode)
: DynamicDataSource(argsCode)
{
    #region Properties
    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    protected TheoryData? TheoryData { get; set; } = null;

    //private InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    //=> new(ArgsCodePropertyHasInvalidValueMessage);

    ///// <summary>
    ///// Gets a message indicating that the <see cref="DynamicDataSource.ArgsCode"/> property has an invalid value.
    ///// </summary>
    //internal string ArgsCodePropertyHasInvalidValueMessage
    //=> $"ArgsCode property has invalid value: {(int)ArgsCode}";
    #endregion

    #region Methods
    #region IsString
    private static bool IsString(object expected)
    => expected is string;
    #endregion

    #region Add
    private void Add<TTestData>(TTestData testData)
    where TTestData : ITestData
    {
        if (TheoryData is TheoryData<TTestData> data)
        {
            data.Add(testData);
            return;
        }

        TheoryData = new TheoryData<TTestData>(testData);
    }

    private void Add<TResult, T1>(
        TResult
        expected,
        T1? arg1)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?> data)
            {
                data.Add(arg1);
                return;
            }

            TheoryData = new TheoryData<T1?>(arg1);
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?> data)
        {
            data.Add(expected, arg1);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?>()
        {
            { expected, arg1 }
        };
    }

    private void Add<TResult, T1, T2>(
        TResult
        expected,
        T1? arg1, T2? arg2)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?> data)
            {
                data.Add(arg1, arg2);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?>()
            {
                { arg1, arg2 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?> data)
        {
            data.Add(expected, arg1, arg2);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?>()
        {
            { expected, arg1, arg2 }
        };
    }

    private void Add<TResult, T1, T2, T3>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?> data)
            {
                data.Add(arg1, arg2, arg3);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?>()
            {
                { arg1, arg2, arg3 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?> data)
        {
            data.Add(expected, arg1, arg2, arg3);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?>()
        {
            { expected, arg1, arg2, arg3 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?> data)
            {
                data.Add(arg1, arg2, arg3, arg4);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?>()
            {
                { arg1, arg2, arg3, arg4 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?>()
        {
            { expected, arg1, arg2, arg3, arg4 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4, T5>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?> data)
            {
                data.Add(arg1, arg2, arg3, arg4, arg5);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?>()
            {
                { arg1, arg2, arg3, arg4, arg5 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4, arg5);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?>()
        {
            { expected, arg1, arg2, arg3, arg4, arg5 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4, T5, T6>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?> data)
            {
                data.Add(arg1, arg2, arg3, arg4, arg5, arg6);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>()
            {
                { arg1, arg2, arg3, arg4, arg5, arg6 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?>()
        {
            { expected, arg1, arg2, arg3, arg4, arg5, arg6 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4, T5, T6, T7>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> data)
            {
                data.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>()
            {
                { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?>()
        {
            { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> data)
            {
                data.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>()
            {
                { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>()
        {
            { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }
        };
    }

    private void Add<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> data)
            {
                data.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return;
            }

            TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>()
            {
                { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }
            };
            return;
        }
        else if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> data)
        {
            data.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return;
        }

        TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>()
        {
            { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }
        };
    }
    #endregion

    #region ResetTheoryData
    /// <summary>
    /// Sets the TheoryData property with null value.
    /// </summary>
    public void ResetTheoryData() => TheoryData = null;
    #endregion

    #region AddOptionalToTheoryData
    /// <summary>
    /// Executes the provided action with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="addTestDataToTheoryData"></param>
    /// <param name="argsCode"></param>
    public void AddOptionalToTheoryData(Action addTestDataToTheoryData, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(addTestDataToTheoryData, nameof(addTestDataToTheoryData));
        WithOptionalArgsCode(this, addTestDataToTheoryData, argsCode);
    }
    #endregion

    #region AddTestDataToTheoryData
    /// <summary>
    /// Adds test _data to a theory _data collection based on the specified argument type and configuration.
    /// This method is used for test cases with a single generic argument (T1).
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">A description or definition of the test case.</param>
    /// <param name="expected">The expected result or outcome of the test case.</param>
    /// <param name="arg1">The first argument to be passed to the test case.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="DynamicDataSource.ArgsCode"/> property has an invalid value
    /// </exception>
    public void AddTestDataToTheoryData<T1>(
        string definition,
        string expected,
        T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?>(
                    definition,
                    expected,
                    arg1));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?>(
                    definition,
                    expected,
                    arg1, arg2));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?>(
                    definition,
                    expected,
                    arg1, arg2, arg3));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?, T5?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7,arg8));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }

    }
    #endregion

    #region AddTestDataReturnsToTheoryData
    /// <summary>
    /// Adds test _data with expected return value to TheoryData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return value.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected return value of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="DynamicDataSource.ArgsCode"/> property has an invalid value
    /// </exception>
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?>(
                    definition,
                    expected,
                    arg1));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2}" />
    /// <typeparam name="T2">The type of the third argument.</typeparam>
    /// <param name="arg2">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?>(
                    definition,
                    expected,
                    arg1, arg2));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?>(
                    definition,
                    expected,
                    arg1, arg2, arg3));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
            Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
                definition,
                expected,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
            break;
        case ArgsCode.Properties:
                Add(expected,
                arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            break;
        default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }
    }
    #endregion

    #region AddTestDataThrowsToTheoryData
    /// <summary>
    /// Adds test _data with expected exception to TheoryData.
    /// </summary>
    /// <typeparam name="TException">The type of the expected exception.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected exception of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="DynamicDataSource.ArgsCode"/> property has an invalid value
    /// </exception>
    public void AddTestDataThrowsToTheoryData<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?>(
                    definition,
                    expected,
                    arg1));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?>(
                    definition,
                    expected,
                    arg1, arg2));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?>(
                    definition,
                    expected,
                    arg1, arg2, arg3));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
        default:
                break;
        }
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
                break;
            case ArgsCode.Properties:
                Add(expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }
    }
    #endregion
    #endregion
}
