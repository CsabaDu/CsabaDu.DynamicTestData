// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;
public class TestCaseDataRowHolder<TTestData>
: DataRowHolder<TTestData, TestCaseTestData>,
ITestCaseDataRowHolder<TTestData>
where TTestData : notnull, ITestData
{
    public TestCaseDataRowHolder(
    TTestData testData,
    IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
    }

    public TestCaseDataRowHolder(
        ITestCaseDataRowHolder<TTestData> other,
        IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
    }

    public override ITestDataRow<TTestData, TestCaseTestData> CreateTestDataRow(
        TTestData testData)
    => new TestCaseDataRow<TTestData>(
        testData);

    public override IDataRowHolder<TestCaseTestData> GetDataRowHolder(
        IDataStrategy dataStrategy)
    => new TestCaseDataRowHolder<TTestData>(
        this,
        dataStrategy);

    public IEnumerable<TestCaseTestData>? GetNamedRows(string? testMethodName)
    => (GetDataRowHolder(DataStrategy) as IEnumerable<ITestDataRow>)
        ?.Select(tdr => (tdr as INamedTestDataRow<TestCaseTestData>)
        !.Convert(DataStrategy, testMethodName));

    public IEnumerable<TestCaseTestData>? GetNamedRows(
        string? testMethodName,
        ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            var dataStrategy =
                GetDataStrategy(argsCode.Value);
            var dataRowHolder =
                (GetDataRowHolder(dataStrategy)
                    as INamedDataRowHolder<TestCaseTestData>)!;

            return dataRowHolder.GetNamedRows(testMethodName);
        }

        return GetNamedRows(testMethodName);
    }
}