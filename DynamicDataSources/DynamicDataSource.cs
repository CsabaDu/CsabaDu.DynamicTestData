// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicDataSource<TRow>(ArgsCode argsCode, Type? expectedResultType)
: DynamicDataSourceBase(argsCode),
IDataStrategy,
ITestDataRows,
IRows<TRow>
{
    #region Fields
    private readonly Type? _expectedResultType = expectedResultType;
    #endregion

    #region Properties
    public bool? WithExpected { get; protected set; }
    protected IDataRowHolder<TRow>? DataRowHolder { get; set; }
    #endregion

    #region Methods
    #region Public methods
    #region Equals
    public bool Equals(IDataStrategy? other)
    => other is not null
        && ArgsCode == other.ArgsCode
        && WithExpected == other.WithExpected;

    public override bool Equals(object? obj)
    => obj is IDataStrategy other
        && Equals(other);
    #endregion

    #region GetHashCode
    public override int GetHashCode()
    => HashCode.Combine(
        ArgsCode,
        WithExpected);
    #endregion

    #region GetDataStrategy
    public IDataStrategy GetDataStrategy(ArgsCode? argsCode)
    {
        argsCode ??= ArgsCode;

        return argsCode == ArgsCode ?
            this
            : new DataStrategy(
                argsCode.Value,
                WithExpected);
    }
    #endregion

    #region GetTestDataRows
    public IEnumerable<ITestDataRow>? GetTestDataRows()
    => DataRowHolder?.GetTestDataRows();
    #endregion

    #region GetRows
    public IEnumerable<TRow>? GetRows(ArgsCode? argsCode)
    => DataRowHolder?.GetRows(argsCode);
    #endregion

    #region ResetDataRowCollection
    public virtual void ResetDataRowHolder()
    => DataRowHolder = null;
    #endregion
    #endregion

    #region Protected virtual methods
    #region Add
    protected virtual void Add<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData
    {
        bool rowCreated = TryGetTestDataRow<ITestDataRow, TTestData>(
            testData,
            out ITestDataRow<TRow, TTestData>? testDataRow);

        if (rowCreated && DataRowHolder is IDataRowHolder<TRow, TTestData> dataRowHolder)
        {
            dataRowHolder.Add(testDataRow!);
        }
    }
    #endregion

    #region TryGetTestDataRow
    protected virtual bool TryGetTestDataRow<TDataRow, TTestData>(
        TTestData testData,
        out ITestDataRow<TRow, TTestData>? testDataRow)
    where TTestData : notnull, ITestData
    {
        testDataRow = default;

        if (DataRowHolder is not IEnumerable<TDataRow> rows
            || !Equals((rows as IDataRowHolder)?.DataStrategy)
            || DataRowHolder.TestDataType != typeof(TTestData)
            || rows.FirstOrDefault() is not ITestDataRow)
        {
            WithExpected =
                _expectedResultType?.IsAssignableFrom(
                    typeof(TTestData));

            InitDataRowHolder(testData);
            return false;
        }

        if ((rows as IEnumerable<INamedTestCase>)!.Any(testData.Equals))
        {
            return false;
        }

        testDataRow = CreateTestDataRow(testData);
        return testDataRow != default;
    }
    #endregion

    #region Add
    protected void Add<T1>(
        string definition,
        string expected,
        T1? arg1)
    => Add(CreateTestData(
        definition,
        expected,
        arg1));

    protected void Add<T1, T2>(
        string definition,
        string expected,
        T1? arg1, T2? arg2)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2));

    protected void Add<T1, T2, T3>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void Add<T1, T2, T3, T4>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void Add<T1, T2, T3, T4, T5>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void Add<T1, T2, T3, T4, T5, T6>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void Add<T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    => Add(CreateTestData(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        string expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    => Add(CreateTestData(
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
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1));

    protected void AddReturns<TStruct, T1, T2>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2));

    protected void AddReturns<TStruct, T1, T2, T3>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddReturns<TStruct, T1, T2, T3, T4>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TStruct : struct
    => Add(CreateTestDataReturns(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TStruct expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TStruct : struct
    => Add(CreateTestDataReturns(
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
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1));

    protected void AddThrows<TException, T1, T2>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2));

    protected void AddThrows<TException, T1, T2, T3>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3));

    protected void AddThrows<TException, T1, T2, T3, T4>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4));

    protected void AddThrows<TException, T1, T2, T3, T4, T5>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));

    protected void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        string definition,
        TException expected,
        T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
    where TException : Exception
    => Add(CreateTestDataThrows(
        definition,
        expected,
        arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    #endregion

    #region GetTestDataType
    protected Type? GetTestDataType()
    => DataRowHolder?.TestDataType;
    #endregion

    #region Abstract methods
    protected abstract ITestDataRow<TRow, TTestData> CreateTestDataRow<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;

    protected abstract void InitDataRowHolder<TTestData>(TTestData testData)
    where TTestData : notnull, ITestData;
    #endregion
    #endregion
    #endregion
}
