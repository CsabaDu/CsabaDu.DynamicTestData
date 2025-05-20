// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;
using CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes;

public class TheoryTestData<TTestData>
: TheoryData<TTestData>,
ITheoryTestData<TTestData>
where TTestData : ITestData
{
    public TheoryTestData(TTestData testData)
    => AddTestData(testData);

    public void AddTestData(TTestData testData)
    => Add(testData);

    internal static object?[] PropertiesToArgs(ITestData testData)
    => testData.PropertiesToArgs(testData is IExpected);

    public ITheoryTestData GetTheoryTestData(TTestData testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TTestData>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1>
: TheoryData<TResult, T1>,
ITheoryTestData<ITestData<TResult, T1>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2>
: TheoryData<TResult, T1, T2>,
ITheoryTestData<ITestData<TResult, T1, T2>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3>
: TheoryData<TResult, T1, T2, T3>,
ITheoryTestData<ITestData<TResult, T1, T2, T3>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4>
: TheoryData<TResult, T1, T2, T3, T4>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4, T5>
: TheoryData<TResult, T1, T2, T3, T4, T5>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4, T5> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4, T5>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData() => this;

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(testData);
        }

        AddTestData(testData);
        return this;
    }
}

public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
where TResult : notnull
{
    public TheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    => AddTestData(testData);

    public void AddTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    => AddRow(
        TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
        .PropertiesToArgs(testData));

    public ITheoryTestData GetTheoryTestData(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    {
        if (Data.Count == 0)
        {
            return new TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(testData);
        }

        AddTestData(testData);
        return this;
    }
}
