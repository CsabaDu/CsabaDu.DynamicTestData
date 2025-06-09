using CsabaDu.DynamicTestData.TestDataHolders;
using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class TestCaseDataRowHolder<TTestData>(
    ArgsCode argsCode,
    TTestData testData)
: DataRowHolder<TTestData, TestCaseData>(
    new DataStrategy(argsCode, testData is ITestDataReturns),
    testData)
where TTestData : notnull, ITestData
{
    public override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow(
        IDataStrategy dataStrategy,
        TTestData testData)
    => new TestCaseTestData<TTestData>(
        testData,
        dataStrategy.ArgsCode);


}
