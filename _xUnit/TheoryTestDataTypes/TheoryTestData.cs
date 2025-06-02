// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes;

public class TheoryTestData<TTestData>
: ITheoryTestData
where TTestData : ITestData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheoryTestData{TTestData}"/> class with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to be added as a row to the collection.</param>
    /// <param name="argsCode"></param>
    internal TheoryTestData(TTestData testData, ArgsCode argsCode)
    => Add(testData, argsCode);

    private readonly List<TestDataRow<TTestData>> data = [];

    public void Add(TTestData testData, ArgsCode argsCode)
    => data.Add(new TestDataRow<TTestData>(testData, argsCode));

    public IEnumerator<ITestDataRow> GetEnumerator()
    => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
   => GetEnumerator();
}

