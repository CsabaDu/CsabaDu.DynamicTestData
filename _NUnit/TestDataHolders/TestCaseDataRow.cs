// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)


namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders;

public sealed class TestCaseDataRow<TTestData>
: TestDataRow<TTestData, TestCaseData>,
ITestCaseDataRow
where TTestData : notnull, ITestData
{
    public TestCaseDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    : base(
        testData,
        dataStrategy)
    {
    }

    //public TestCaseDataRow(
    //    TTestData testData,
    //    ArgsCode argsCode)
    //: base(
    //    testData,
    //    argsCode,
    //    nameof(ITestDataReturns))
    //{
    //}
        
    public TestCaseData Convert(string? testMethodName)
    => new TestCaseTestData<TTestData>(TestData, DataStrategy.ArgsCode, testMethodName);

    public override TestCaseData Convert()
    => new TestCaseTestData<TTestData>(TestData, DataStrategy.ArgsCode);

    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestCaseDataRow<TTestData>(testData, dataStrategy);
}