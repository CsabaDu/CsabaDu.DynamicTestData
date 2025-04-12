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
namespace CsabaDu.DynamicTestData.xUnit.v3.DynamicDataSources;

public abstract class DynamicTheoryTestDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    internal const string ArgumentsAreSuitableForCreating_ = "Arguments are suitable for creating ";

    #region Properties
    [NotNull]
    protected TheoryTestData TheoryTestData { get; set; } = new(argsCode);

    internal string ArgumentsMismatchMessageEnd => " elements and do not match with the initiated "
    + TestDataType!.Name + " instance's type parameters.";

    private Type? TestDataType => TheoryTestData.FirstOrDefault()?.TestData.GetType();
    #endregion

    #region Methods
    #region ResetTheoryTestData
    public void ResetTheoryTestData() => TheoryTestData = new(ArgsCode);
    #endregion

    #region AddOptionalToTheoryTestData
    public void AddOptionalToTheoryTestData(Action addTestDataToTheoryTestData, ArgsCode argsCode)
    {
        ArgumentNullException.ThrowIfNull(addTestDataToTheoryTestData, nameof(addTestDataToTheoryTestData));
        WithOptionalArgsCode(this, addTestDataToTheoryTestData, argsCode);
    }
    #endregion

    #region AddTestDataToTheoryTestData
    public void AddTestDataToTheoryTestData<T1>(string definition, string expected, T1? arg1)
    {
        var testData = new TestData<T1>(definition, expected, arg1);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
    {
        var testData = new TestData<T1, T2>(definition, expected, arg1, arg2);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
    {
        var testData = new TestData<T1, T2, T3>(definition, expected, arg1, arg2, arg3);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
        var testData = new TestData<T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    {
        var testData = new TestData<T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    {
        var testData = new TestData<T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    {
        var testData = new TestData<T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    {
        var testData = new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataToTheoryTestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    {
        var testData = new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        AddToTheoryTestData(testData);
    }
    #endregion

    #region AddTestDataReturnsToTheoryTestData
    public void AddTestDataReturnsToTheoryTestData<TStruct, T1>(string definition, TStruct expected, T1? arg1)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1>(definition, expected, arg1);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2>(definition, expected, arg1, arg2);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3>(definition, expected, arg1, arg2, arg3);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataReturnsToTheoryTestData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    {
        var testData = new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        AddToTheoryTestData(testData);
    }
    #endregion

    #region AddTestDataThrowsToTheoryTestData
    public void AddTestDataThrowsToTheoryTestData<TException, T1>(string definition, TException expected, T1? arg1)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1>(definition, expected, arg1);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2>(definition, expected, arg1, arg2);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3>(definition, expected, arg1, arg2, arg3);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4>(definition, expected, arg1, arg2, arg3, arg4);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4, T5>(definition, expected, arg1, arg2, arg3, arg4, arg5);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        AddToTheoryTestData(testData);
    }

    public void AddTestDataThrowsToTheoryTestData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    {
        var testData = new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(definition, expected, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        AddToTheoryTestData(testData);
    }
    #endregion

    #region AddToTheoryTestData
    private void AddToTheoryTestData(TestData testData)
    {
        if (TheoryTestData.Count == 0)
        {
            TheoryTestData.Add(testData);
        }

        Type testDataType = testData.GetType();

        if (testDataType != TestDataType)
        {
            throw new ArgumentException(GetArgumentsMismatchMessage(testDataType));
        }

        TheoryTestData.Add(testData);
    }
    #endregion

    #region GetArgumentsMismatchMessage
    internal string GetArgumentsMismatchMessage(Type  testDataType)
    => ArgumentsAreSuitableForCreating_ + testDataType.Name
        + ArgumentsMismatchMessageEnd;
    #endregion
    #endregion
}
