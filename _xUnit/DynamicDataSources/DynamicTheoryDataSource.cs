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
namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

/// <summary>
/// Base class containing methods to add test data to TheoryData.
/// </summary>
public abstract class DynamicTheoryDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    #region Exception message elements constant strings
    internal const string ArgumentsAreSuitableForCreating_ = "Arguments are suitable for creating ";
    internal const string ArgsCodePropertyHasInvalidValue_ = "ArgsCode property has invalid value: ";
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    protected TheoryData? TheoryData { get; set; } = null;

    internal string ArgumentsMismatchMessageEnd => " elements and do not match with the initiated "
        + TheoryData?.GetType().Name + " instance's type parameters.";

    private InvalidOperationException ArgsCodeProperyValueInvalidOperationException
    => new(ArgsCodePropertyHasInvalidValue_ + (int)ArgsCode);
    #endregion

    #region Methods
    /// <summary>
    /// Sets the TheoryData property with null value.
    /// </summary>
    public void ResetTheoryData() => TheoryData = null;

    /// <summary>
    /// Generates a descriptive error message for an arguments mismatch exception.
    /// This message indicates that the provided arguments are suitable for creating elements of the specified <paramref name="theoryDataType"/>
    /// but do not match the type parameters of the currently initiated <see cref="TheoryData"/> instance.
    /// </summary>
    /// <typeparam name="TTheoryData">The expected type of the theory data. Must inherit from <see cref="Xunit.TheoryData"/>.</typeparam>
    /// <returns>A formatted error message describing the mismatch between the arguments and the expected type parameters.</returns>
    internal string GetArgumentsMismatchMessage<TTheoryData>() where TTheoryData : TheoryData
    => ArgumentsAreSuitableForCreating_ + typeof(TTheoryData).Name
        + ArgumentsMismatchMessageEnd;

    /// <summary>
    /// Validates and returns the provided theory data instance, ensuring it matches the expected type.
    /// If the <see cref="TheoryData"/> property is null or different type, it initializes it with the provided <paramref name="theoryData"/>.
    /// </summary>
    /// <typeparam name="TTheoryData">The expected type of the theory data. Must inherit from <see cref="Xunit.TheoryData"/>.</typeparam>
    /// <param name="theoryData">The theory data instance to validate or initialize.</param>
    /// <returns>The validated or initialized theory data instance of type <typeparamref name="TTheoryData"/>.</returns>
    private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData) where TTheoryData : TheoryData
    => (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
        typedTheoryData
        : throw new ArgumentException(GetArgumentsMismatchMessage<TTheoryData>());

    #region AddOptionalToTheoryData
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
    public void AddTestDataToTheoryData<T1>(string definition, string expected, T1? arg1)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestData<T1?>> initTestDataTheoryData() => [];
        static TheoryData<T1?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestData<T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?> getTestData() => new(definition, expected, arg1, arg2, arg3);

        static TheoryData<TestData<T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4);

        static TheoryData<TestData<T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?, T5?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5);

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?, T5?, T6?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataToTheoryData{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
        #endregion
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
    public void AddTestDataReturnsToTheoryData<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestDataReturns<TStruct, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the third argument.</typeparam>
    /// <param name="arg4">The third argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?> getTestData() => new(definition, expected, arg1, arg2, arg3);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5}" />
        /// <typeparam name="T6">The type of the sixth argument.</typeparam>
        /// <param name="arg6">The sixth argument to be passed to the test case.</param>
        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataReturnsToTheoryData{T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
        #endregion
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
    public void AddTestDataThrowsToTheoryData<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?> getTestData() => new(definition, expected, arg1);

        static TheoryData<TestDataThrows<TException, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1}" />
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <param name="arg2">The second argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?> getTestData() => new(definition, expected, arg1, arg2);

        static TheoryData<TestDataThrows<TException, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2}" />
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <param name="arg3">The third argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?> getTestData() => new(definition, expected, arg1, arg2, arg3);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3}" />
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <param name="arg4">The fourth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4}" />
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <param name="arg5">The fifth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5}" />
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <param name="arg6">The sixth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6}" />
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <param name="arg7">The seventh argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6, T7}" />
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <param name="arg8">The eighth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
        #endregion
    }

    /// <inheritdoc cref="AddTestDataThrowsToTheoryData{TException, T1, T2, T3, T4, T5, T6, T7, T8}" />
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <param name="arg9">The ninth argument to be passed to the test case.</param>
    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                CheckedTheoryData(initTestDataTheoryData()).Add(getTestData());
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }

        #region Local methods
        TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> getTestData() => new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
        #endregion
    }
    #endregion
    #endregion
}
