// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicDataSource<TRow>(ArgsCode argsCode, bool? withExpected)
: DynamicDataSourceBase<TRow>(argsCode, withExpected),
IRows<TRow>

{
    #region Properties
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }
    #endregion

    #region Methods
    #region GetRows
    public IEnumerable<TRow>? GetRows()
    => DataRowHolder?.GetRows();

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataRowHolder?.GetRows(argsCode);
    #endregion

    #region ResetDataRowCollection
    public void ResetDataRowCollection()
    => DataRowHolder = null;
    #endregion

    #region Add
    #region Private Add
    private void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        if (DataRowHolder is not
            IDataRowHolder<TTestData, TRow> typedCollection)
        {
            InitDataRowHolder(testData);
            return;
        }

        if (typedCollection.Any(testData.Equals))
        {
            return;
        }

        var testDataRow = CreateTestDataRow(testData);
        typedCollection.Add(testDataRow);
    }
    #endregion

    #region Protected Add
    protected void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
    => Add(new TestData<T1>(
        definition,
        expected,
        arg1));

    protected void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => Add(new TestData<T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void Add<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => Add(new TestData<T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void Add<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => Add(new TestData<T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void Add<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => Add(new TestData<T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void Add<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => Add(new TestData<T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void Add<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => Add(new TestData<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion
    #endregion

    #region AddReturns
    protected void AddReturns<TStruct, T1>(
        string definition,
        TStruct expected,
        T1? arg1)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1>(
        definition,
        expected,
        arg1));

    protected void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void AddReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => Add(new TestDataReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region AddThrows
    protected void AddThrows<TException, T1>(
        string definition,
        TException expected,
        T1? arg1)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1>(
        definition,
        expected,
        arg1));

    protected void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2>(
        definition,
        expected,
        arg1, arg2));

    protected void AddThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3>(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4>(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => Add(new TestDataThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region Abstract methods
    protected abstract ITestDataRow<TTestData, TRow> CreateTestDataRow<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
}

public abstract class DynamicDataSource(ArgsCode argsCode, bool? withExpected)
: DynamicDataSource<object?[]>(argsCode, withExpected)
{
    protected override ITestDataRow<TTestData, object?[]> CreateTestDataRow<TTestData>(
        TTestData testData)
    => new TestDataRow<TTestData>(
        testData,
        this);

    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    => DataRowHolder = new DataRowHolder<TTestData>(
        testData,
        this);
}