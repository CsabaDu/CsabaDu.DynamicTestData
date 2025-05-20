// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryTestDataSource(ArgsCode argsCode)
: DynamicTheoryDataSourceBase(argsCode)
{
    protected ITheoryTestData? TheoryTestData { get; set; } = null;

    protected override sealed string TheoryDataTypeName
    => TheoryTestData?.GetType().Name ?? string.Empty;

    private bool IsTheoryTestDataNull
    => TheoryTestData is null;

    public void ResetTheoryTestData()
    {
        TheoryTestData = null;
    }

    #region AddOptionalToTheoryTestData
    /// <summary>
    /// Executes the provided action with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="addTestDataToTheoryTestData"></param>
    /// <param name="argsCode"></param>
    public void AddOptionalToTheoryTestData(
        Action addTestDataToTheoryTestData,
        ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(
            addTestDataToTheoryTestData,
            nameof(addTestDataToTheoryTestData));
        WithOptionalArgsCode(this,
            addTestDataToTheoryTestData,
            argsCode);
    }
    #endregion

    public void AddToTheoryTestData<TResult, T1>(
        ITestData<TResult, T1> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2>(
        ITestData<TResult, T1, T2> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3>(
        ITestData<TResult, T1, T2, T3> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4>(
        ITestData<TResult, T1, T2, T3, T4> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5>(
        ITestData<TResult, T1, T2, T3, T4, T5> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4, T5> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4, T5>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4, T5, T6> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }

    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    where TResult : notnull
    {
        switch (ArgsCode)
        {
            case ArgsCode.Instance:
                if (TheoryTestData is TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>> tInstance)
                    tInstance.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            case ArgsCode.Properties:
                if (TheoryTestData is TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> tProperties)
                    tProperties.AddTestData(testData);
                else if (IsTheoryTestDataNull)
                    TheoryTestData = new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(testData);
                else throw ArgumentsMismatchException(testData);
                break;
            default:
                throw ArgsCodeProperyValueInvalidOperationException;
        }
    }
}
