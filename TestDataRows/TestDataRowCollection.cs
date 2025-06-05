// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using System.Collections;

namespace CsabaDu.DynamicTestData.TestDataRows;

public abstract class TestDataRowCollection<TTestData, TRow>
: ITestDataRowCollecttion<TTestData, TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheoryTestData{TTestData}"/> class with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    internal TestDataRowCollection(
        TTestData testData,
        ArgsCode argsCode,
        bool? withExpected)
    => Add(CreateTestDataRow(
        testData,
        argsCode,
        withExpected));

    protected readonly List<ITestDataRow<TTestData, TRow>> data = [];

    public Type TestDataType
    => typeof(TTestData);

    public IEnumerable<TRow> GetRows()
    => data.Select(tdr => tdr.Convert());

    public IEnumerator<ITestDataRow> GetEnumerator()
    => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

    public bool Equals(ITestDataType? other)
    => other is not null
        && other.TestDataType == TestDataType;

    public IEnumerable<ITestDataRow<TRow>> GetTestDataRows()
    => data;

    public void Add(ITestDataRow<TTestData, TRow> testDataRow)
    => data.Add(testDataRow);

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData,
        ArgsCode argsCode,
        bool? withExpected);
}

public sealed class TestDataRowCollection<TTestData>(
    TTestData testData,
    ArgsCode argsCode,
    bool? withExpected)
: TestDataRowCollection<TTestData, object?[]>(
    testData,
    argsCode,
    withExpected)
where TTestData : notnull, ITestData
{
    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        ArgsCode argsCode,
        bool? withExpected)
    => new TestDataRow<TTestData>(
        testData,
        argsCode,
        withExpected);
}