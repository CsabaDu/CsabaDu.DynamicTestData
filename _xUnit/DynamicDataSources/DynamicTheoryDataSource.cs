// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

/// <summary>
/// Base class containing methods to add test data to TheoryData.
/// </summary>
public abstract class DynamicTheoryDataSource(ArgsCode argsCode)
: DynamicTheoryDataSourceBase(argsCode)
{
    #region Properties
    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    protected TheoryData? TheoryData { get; set; } = null;
    #endregion

    #region Methods
    #region AddToTheoryData
    private static bool IsString(object expected)
    => expected is string;
    private void AddToTheoryData<TTestData>(TTestData testData)
    where TTestData : ITestData
    {
        if (TheoryData is TheoryData<TTestData> theoryData)
        {
            theoryData.Add(testData);
        }
        else
        {
            TheoryData = new TheoryData<TTestData>(testData);
        }
    }

    private void AddToTheoryData<TResult, T1>(
        TResult
        expected,
        T1? arg1)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?> theoryData)
            {
                theoryData.Add(arg1);
            }
            else
            {
                TheoryData = new TheoryData<T1?>(arg1);
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?> theoryData)
            {
                theoryData.Add(expected, arg1);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?>()
                {
                    { expected, arg1 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2>(
        TResult
        expected,
        T1? arg1, T2? arg2)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?> theoryData)
            {
                theoryData.Add(arg1, arg2);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?>()
                {
                    { arg1, arg2 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?>()
                {
                    { expected, arg1, arg2 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?>()
                {
                    { arg1, arg2, arg3 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?>()
                {
                    { expected, arg1, arg2, arg3 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?>()
                {
                    { arg1, arg2, arg3, arg4 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?>()
                {
                    { expected, arg1, arg2, arg3, arg4 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4, T5>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?>()
                {
                    { arg1, arg2, arg3, arg4, arg5 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?>()
                {
                    { expected, arg1, arg2, arg3, arg4, arg5 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4, T5, T6>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4, arg5, arg6);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?>()
                {
                    { arg1, arg2, arg3, arg4, arg5, arg6 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?>()
                {
                    { expected, arg1, arg2, arg3, arg4, arg5, arg6 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4, T5, T6, T7>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>()
                {
                    { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?>()
                {
                    { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>()
                {
                    { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>()
                {
                    { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }
                };
            }
        }
    }

    private void AddToTheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        TResult
        expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TResult : notnull
    {
        if (IsString(expected))
        {
            if (TheoryData is TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> theoryData)
            {
                theoryData.Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            else
            {
                TheoryData = new TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>()
                {
                    { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }
                };
            }
        }
        else
        {
            if (TheoryData is TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> theoryData)
            {
                theoryData.Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            else
            {
                TheoryData = new TheoryData<TResult, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>()
                {
                    { expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }
                };
            }
        }
    }
    #endregion

    #region ResetTheoryData
    /// <summary>
    /// Sets the TheoryData property with null value.
    /// </summary>
    public void ResetTheoryData() => TheoryData = null;
    #endregion

    //#region CheckedTheoryData
    ///// <summary>
    ///// Validates and returns the provided theory data instance, ensuring it matches the expected type.
    ///// If the <see cref="TheoryData"/> property is null or different type, it initializes it with the provided <paramref name="theoryData"/>.
    ///// </summary>
    ///// <typeparam name="TTheoryData">The expected type of the theory data. Must inherit from <see cref="Xunit.TheoryData"/>.</typeparam>
    ///// <param name="theoryData">The theory data instance to validate or initialize.</param>
    ///// <returns>The validated or initialized theory data instance of type <typeparamref name="TTheoryData"/>.</returns>
    //private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData)
    //where TTheoryData : TheoryData
    //=> (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
    //    typedTheoryData
    //    : throw ArgumentsMismatchException;
    //#endregion

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
    /// Adds test data to a theory data collection based on the specified argument type and configuration.
    /// This method is used for test cases with a single generic argument (T1).
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">A description or definition of the test case.</param>
    /// <param name="expected">The expected result or outcome of the test case.</param>
    /// <param name="arg1">The first argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1>(
        string definition,
        string expected,
        T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?> testData = new(
                    definition,
                    expected,
                    arg1);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?> testData = new(
                    definition,
                    expected,
                    arg1, arg2);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?, T5?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?, T5?, T6?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?> testData = new(
                    definition,
                    expected,
                    arg1);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?> testData = new(
                    definition,
                    expected,
                    arg1, arg2);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the third argument.</typeparam>
    /// <param name="arg4">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
    public void AddTestDataThrowsToTheoryData<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?> testData = new(
                    definition,
                    expected,
                    arg1);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?> testData = new(
                    definition,
                    expected,
                    arg1, arg2);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
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
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(
                    definition,
                    expected,
                    arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                AddToTheoryData(testData);
                break;
            case ArgsCode.Properties:
                AddToTheoryData(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }
    #endregion
    #endregion
}
