// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

/// <summary>
/// Represents a dynamic data source for parameterized tests, supporting the addition of test data and expected outcomes
/// for use in theory-based testing.
/// </summary>
/// <remarks>This abstract class provides methods to manage and manipulate test data collections, including adding
/// test cases with varying numbers of arguments, expected return values, or expected exceptions. It is designed to
/// facilitate the creation of dynamic test scenarios for parameterized tests.</remarks>
/// <param name="argsCode">The <see cref="ArgsCode"/> type enum which determines the strategy of creating test parameters</param>
public abstract class DynamicTheoryDataSource(ArgsCode argsCode)
: DynamicDataSourceBase(argsCode)
{
    #region Properties
    /// <summary>
    /// Gets or sets the TheoryTestData used for parameterized tests.
    /// </summary>
    protected ITheoryTestData? TheoryTestData { get; set; } = null;
    #endregion

    #region Methods
    #region ResetTheoryData
    /// <summary>
    /// Sets the TheoryTestData property with null value.
    /// </summary>
    public void ResetTheoryData() => TheoryTestData = null;
    #endregion

    #region AddOptional
    /// <summary>
    /// Executes the provided action with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="add"></param>
    /// <param name="argsCode"></param>
    public void AddOptional(Action add, ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(add, nameof(add));
        WithOptionalArgsCode(this, add, argsCode);
    }
    #endregion

    #region Add
    #region Private Add

    /// <summary>
    /// Adds the specified test data to the current theory data collection.
    /// </summary>
    /// <remarks>If the current theory data collection is of type <see cref="TheoryTestData{T}"/>, the test
    /// data is added to it. Otherwise, a new instance of <see cref="TheoryTestData{T}"/> is created and initialized
    /// with the specified test data.</remarks>
    /// <typeparam name="TTestData">The type of the test data, which must implement <see cref="ITestData"/>.</typeparam>
    /// <param name="testData">The test data to add. Cannot be <see langword="null"/>.</param>
    private void Add<TTestData>(TTestData testData)
    where TTestData :  notnull, ITestData
    {
        if (TheoryTestData is TheoryTestData<TTestData> theoryTestData)
        {
            theoryTestData.Add(testData, ArgsCode);
            return;
        }

        TheoryTestData = new TheoryTestData<TTestData>(testData, ArgsCode);
    }
    #endregion

    /// <summary>
    /// Adds test _data to a theory _data collection based on the specified argument type and configuration.
    /// This method is used for test cases with a single generic argument (T1).
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <param name="definition">A description or definition of the test case.</param>
    /// <param name="expected">The expected result or outcome of the test case.</param>
    /// <param name="arg1">The first argument to be passed to the test case.</param>
    /// Thrown when the <see cref="DynamicDataSourceBase.ArgsCode"/> property has an invalid value
    /// </exception>
    public void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
    => Add(new TestData<T1?>(
        definition,
        expected,
        arg1));

    /// <inheritdoc cref="Add{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => Add(new TestData<T1?, T2?>(
        definition,
        expected,
        arg1, arg2));

    /// <inheritdoc cref="Add{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void Add<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => Add(new TestData<T1?, T2?, T3?>(
        definition,
        expected,
        arg1, arg2, arg3));

    /// <inheritdoc cref="Add{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => Add(new TestData<T1?, T2?, T3?, T4?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    /// <inheritdoc cref="Add{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => Add(new TestData<T1?, T2?, T3?, T4?, T5?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    /// <inheritdoc cref="Add{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    /// <inheritdoc cref="Add{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    /// <inheritdoc cref="Add{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    /// <inheritdoc cref="Add{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => Add(new TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region AddReturns
    /// <summary>
    /// Adds test _data with expected return value to TheoryTestData.
    /// </summary>
    /// <typeparam name="TStruct">The type of the expected return value.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected return value of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="DynamicDataSourceBase.ArgsCode"/> property has an invalid value
    /// </exception>
    public void AddReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?>(
        definition,
        expected,
        arg1));

    /// <inheritdoc cref="AddReturns{T1, T2}" />
    /// <typeparam name="T2">The type of the third argument.</typeparam>
    /// <param name="arg2">The third argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?>(
        definition,
        expected,
        arg1, arg2));

    /// <inheritdoc cref="AddReturns{T1, T2, T3}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?>(
        definition,
        expected,
        arg1, arg2, arg3));

    /// <inheritdoc cref="AddReturns{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    /// <inheritdoc cref="AddReturns{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    /// <inheritdoc cref="AddReturns{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    /// <inheritdoc cref="AddReturns{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    /// <inheritdoc cref="AddReturns{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    /// <inheritdoc cref="AddReturns{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
   => Add(new TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region AddThrows
    /// <summary>
    /// Adds test _data with expected exception to TheoryTestData.
    /// </summary>
    /// <typeparam name="TException">The type of the expected exception.</typeparam>
    /// <typeparam name="T1">The type of the argument.</typeparam>
    /// <param name="definition">The definition of the test case.</param>
    /// <param name="expected">The expected exception of the test case.</param>
    /// <param name="arg1">The argument for the test case.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="DynamicDataSourceBase.ArgsCode"/> property has an invalid value
    /// </exception>
    public void AddThrows<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?>(
        definition,
        expected,
        arg1));

    /// <inheritdoc cref="AddThrows{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?>(
        definition,
        expected,
        arg1, arg2));

    /// <inheritdoc cref="AddThrows{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?>(
        definition,
        expected,
        arg1, arg2, arg3));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    /// <inheritdoc cref="AddThrows{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion
    #endregion
}
