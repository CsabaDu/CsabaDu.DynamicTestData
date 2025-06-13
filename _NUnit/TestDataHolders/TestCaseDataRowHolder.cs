// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;
public class TestCaseDataRowHolder<TTestData>(
    TTestData testData,
    IDataStrategy dataStrategy)
: DataRowHolder<TTestData, TestCaseData>(
    testData,
    dataStrategy),
ITestCaseDataRowHolder
where TTestData : notnull, ITestData
{
    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy dataStrategy)
    => new TestCaseDataRow<TTestData>(
        testData,
        dataStrategy);

    public IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName)
    => dataRows
        .Select(tdr => (tdr as ITestCaseDataRow)!
        .Convert(testMethodName));

    public IEnumerable<TestCaseData>? GetNamedRows(
        string? testMethodName,
        ArgsCode? argsCode)
    {
        if (argsCode.HasValue)
        {
            var dataStrategy = GetDataStrategy(argsCode.Value);

            return dataRows.Select(
                tdr => new TestCaseDataRow<TTestData>(
                    tdr.TestData,
                    dataStrategy)
                    .Convert(testMethodName));
        }

        return GetNamedRows(testMethodName);
    }
}