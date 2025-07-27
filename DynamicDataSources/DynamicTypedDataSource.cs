// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicTypedDataSource<TDataHolder>(ArgsCode argsCode, PropertyCode propertyCode)
: DynamicDataSource<TDataHolder>(argsCode, propertyCode)
where TDataHolder : class
{
    #region Add
    protected virtual void Add<TResult, T1>(ITestData<TResult, T1> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2>(ITestData<TResult, T1, T2> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3>(ITestData<TResult, T1, T2, T3> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4>(ITestData<TResult, T1, T2, T3, T4> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4, T5>(ITestData<TResult, T1, T2, T3, T4, T5> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4, T5>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4, T5, T6>(ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4, T5, T6>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4, T5, T6, T7>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void Add<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    where TResult : notnull
    => Add<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));
    #endregion

    #region InitDataHolder
    protected virtual void InitDataHolder<TResult, T1>(ITestData<TResult, T1> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2>(ITestData<TResult, T1, T2> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3>(ITestData<TResult, T1, T2, T3> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4>(ITestData<TResult, T1, T2, T3, T4> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4, T5>(ITestData<TResult, T1, T2, T3, T4, T5> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4, T5>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4, T5, T6>(ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4, T5, T6>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4, T5, T6, T7>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));

    protected virtual void InitDataHolder<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    where TResult : notnull
    => InitDataHolder<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(testData
        ?? throw new ArgumentNullException(nameof(testData)));
    #endregion
}