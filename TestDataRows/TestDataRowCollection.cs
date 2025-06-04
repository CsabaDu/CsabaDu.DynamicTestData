// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using System.Collections;

namespace CsabaDu.DynamicTestData.TestDataRows;

public abstract class TestDataRowCollection<TTestData, TRow>
: ITestDataRowCollecttion<TTestData, TRow>, ITestCaseName
where TTestData : notnull, ITestData
where TRow : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheoryTestData{TTestData}"/> class with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    internal TestDataRowCollection(TTestData testData, ArgsCode argsCode, bool? withExpected)
    {
        Add(testData, argsCode, withExpected);
        TestCaseName = testData.TestCaseName;
    }

    protected readonly List<ITestDataRow<TTestData, TRow>> data = [];

    public string TestCaseName {  get; init; }

    public IEnumerable<TRow> GetRows()
    => data.Select(x => x.Convert());

    public abstract void Add(TTestData testData, ArgsCode argsCode, bool? withExpected);

    public IEnumerator<ITestDataRow> GetEnumerator()
    => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public bool Equals(ITestCaseName? other)
    => other is not null
        && other.TestCaseName == TestCaseName;
}

public class TestDataRowCollection<TTestData>(TTestData testData, ArgsCode argsCode, bool? withExpected)
: TestDataRowCollection<TTestData, object?[]>(testData, argsCode, withExpected)
where TTestData : notnull, ITestData
{
    public override void Add(TTestData testData, ArgsCode argsCode, bool? withExpected)
    => data.Add(new TestDataRow<TTestData>(testData, argsCode, withExpected));
}
