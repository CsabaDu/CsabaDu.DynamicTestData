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
    /// <summary>
    /// Gets or sets the TheoryData used for parameterized tests.
    /// </summary>
    protected TheoryData? TheoryData { get; set; }

    /// <summary>
    /// Sets the TheoryData property with default value.
    /// </summary>
    protected void ResetTheoryData() => TheoryData = default;

    internal ArgumentException ArgumentsMismatchException(Type expectedType)
    => new($"Arguments are suitable for creating {expectedType.Name} elements" +
        $" and do not match with the initiated {TheoryData!.GetType().Name} instance's type parameters.");

    private TTheoryData CheckedTheoryData<TTheoryData>(TTheoryData theoryData) where TTheoryData : TheoryData
    => (TheoryData ??= theoryData) is TTheoryData typedTheoryData ?
        typedTheoryData
        : throw ArgumentsMismatchException(typeof(TTheoryData));

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
                TestData<T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?>> initTestDataTheoryData() => [];
        static TheoryData<T1?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
    }

    public void AddTestDataToTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }

        static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
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
                TestDataReturns<TStruct, T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData!);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
    }

    public void AddTestDataReturnsToTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }

        static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
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
                TestDataThrows<TException, T1?> testData = new(definition, expected, arg1);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?> testData = new(definition, expected, arg1, arg2);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?> testData = new(definition, expected, arg1, arg2, arg3);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?> testData = new(definition, expected, arg1, arg2, arg3, arg4);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> initTheoryData() => [];
    }

    public void AddTestDataThrowsToTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> testData = new(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                CheckedTheoryData(initTestDataTheoryData()).Add(testData);
                break;
            case ArgsCode.Properties:
                CheckedTheoryData(initTheoryData()).Add(expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                break;
            default:
                break;
        }

        static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> initTestDataTheoryData() => [];
        static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> initTheoryData() => [];
    }
    #endregion
}
