// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders;
using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSourceBase<TRow>(argsCode),
IRows<TRow>
{
    protected string? _resultTypeName = expectedResultType?.Name;

    #region Properties
    public override sealed bool? WithExpected { get; protected set; }
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }
    #endregion

    #region Methods
    #region GetRows
    public IEnumerable<TRow>? GetRows()
    => DataRowHolder?.GetRows();

    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataRowHolder?.GetRows(argsCode);
    #endregion

    #region GetTestDataRow
    protected bool TryGetTestDataRow<TTestData>(TTestData testData, out ITestDataRow<TTestData, TRow>? testDataRow)
    where TTestData : notnull, ITestData
    {
        testDataRow = default;

        if (DataRowHolder?.TestDataType != typeof(TTestData))
        {
            InitDataRowHolder(testData);
            return false;
        }

        var testDataRows =
            DataRowHolder as IEnumerable<ITestDataRow>;

        var dataStrategy =
            testDataRows
            ?.FirstOrDefault()
            ?.DataStrategy;

        if (!Equals(dataStrategy))
        {
            InitDataRowHolder(testData);
            return false;
        }

        if (testDataRows!.Any(testData.Equals))
        {
            return false;
        }

        testDataRow = CreateTestDataRow(testData);
        return testDataRow != default;
    }
    #endregion

    #region ResetDataRowCollection
    public virtual void ResetDataRowHolder()
    => DataRowHolder = null;
    #endregion

    #region Virtual Add
    protected virtual void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        var success = TryGetTestDataRow(
            testData,
            out ITestDataRow<TTestData, TRow>? testDataRow);

        if (success && DataRowHolder is IDataRowHolder<TTestData, TRow> dataRowHolder)
        {
            dataRowHolder.Add(testDataRow!);
        }
    }
    #endregion

    #region Add
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

    protected Type? GetTestDataType()
    => DataRowHolder?.TestDataType;

    #region Abstract methods
    protected abstract ITestDataRow<TTestData, TRow> CreateTestDataRow<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
}

public abstract class DynamicDataSource(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSource<object?[]>(argsCode, expectedResultType)
{
    protected override ITestDataRow<TTestData, object?[]> CreateTestDataRow<TTestData>(
        TTestData testData)
    => new TestDataRow<TTestData>(
        testData,
        this);

    protected override void InitDataRowHolder<TTestData>(
        TTestData testData)
    {
        DataRowHolder = new DataRowHolder<TTestData>(
            testData,
            this);

        WithExpected = _resultTypeName == null ?
            null
            : GetTestDataType()?.GetInterface(_resultTypeName)
            != null;
    }
}
