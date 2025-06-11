// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;

//public abstract class TestCaseDataRowHolder<TTestData, TestCaseData>
//: IDataRowHolder<TTestData, TestCaseData>,
//INamedRows<TestCaseData>
//where TTestData : notnull, ITestData

//{
//    /// <summary>
//    /// Initializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified test data.
//    /// </summary>
//    /// <param name="testData">The test data to be added as a row to the collection.</param>
//    /// <param name="argsCode"></param>
//    public TestCaseDataRowHolder(
//        IDataStrategy dataStrategy,
//        TTestData testData)
//    {
//        Add(CreateTestDataRow(
//            testData,
//            dataStrategy
//                ?? throw new ArgumentNullException(
//                    nameof(dataStrategy))));

//        _withExpected = dataStrategy.WithExpected;
//    }

//    protected readonly List<ITestDataRow<TTestData, TestCaseData>> data = [];
//    private readonly bool? _withExpected;

//    public IEnumerable<TestCaseData>? GetRows()
//    => data as IEnumerable<TestCaseData>;

//    public IEnumerable<TestCaseData>? GetRows(ArgsCode? argsCode)
//    {
//        if (argsCode.HasValue)
//        {
//            var dataStrategy = new DataStrategy(
//                argsCode.Value,
//                _withExpected);

//            return data.Select(
//                tdr => tdr.CreateTestDataRow(
//                    tdr.TestData,
//                    dataStrategy)
//                .Convert());
//        }

//        return GetRows();
//    }

//    public IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName)
//    => data.Select(tdr => (tdr as TestCaseDataRow)!.SetTestName(testMethodName)).Convert();

//    public IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName, ArgsCode? argsCode)
//    {
//        throw new NotImplementedException();
//    }

//    public IEnumerator<ITestDataRow> GetEnumerator()
//    => data.GetEnumerator();

//    IEnumerator IEnumerable.GetEnumerator()
//    => GetEnumerator();

//    public IEnumerable<ITestDataRow<TestCaseData>> GetTestDataRows()
//    => data;

//    public void Add(ITestDataRow<TTestData, TestCaseData> testDataRow)
//    => data.Add(testDataRow);

//    public abstract ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
//        TTestData testData,
//        IDataStrategy dataStrategy);
//}

public sealed class TestCaseDataRowHolder<TTestData>(
    TTestData testData,
    ArgsCode argsCode)
: DataRowHolder<TTestData, TestCaseData>(
    testData,
    new DataStrategy(
        argsCode,
        IsTestDataReturns(testData))),
ITestCaseDataRowHolder
where TTestData : notnull, ITestData
{
    public TestCaseDataRowHolder(
        TTestData testData,
        IDataStrategy? dataStrategy)
    : this(
        testData,
        dataStrategy?.ArgsCode ?? default)
    {
    }

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName)
    => data
        .Select(tdr => (tdr as ITestCaseDataRow)!
        .Convert(testMethodName));

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName,
        ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            return data
                .Select(tdr => new TestCaseDataRow<TTestData>(
                    tdr.TestData,
                    argsCode.Value)
                .Convert(testMethodName));
        }

        return GetNamedRows(testMethodName);
    }
}