//// SPDX-License-Identifier: MIT
//// Copyright (c) 2025. Csaba Dudas (CsabaDu)

//using CsabaDu.DynamicTestData.NUnit.TestDataTypes;
//using NUnit.Framework;

//namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

//public class TestCaseDataRowHolder<TTestData>(
//    TTestData testData,
//    ArgsCode argsCode)
//: DataRowHolder<TTestData, TestCaseData>(
//    testData,
//    new DataStrategy(argsCode, testData is ITestDataReturns))
//where TTestData : notnull, ITestData
//{
//    public override ITestDataRow<TTestData, TestCaseTestData> CreateTestDataRow(
//        TTestData testData)
//    => new TestDataRow<TTestData, TestCaseData>(
//        testData);

//    public override IDataRowHolder<TestCaseData> GetDataRowHolder(IDataStrategy dataStrategy)
//    {
//        throw new NotImplementedException();
//    }
//}
