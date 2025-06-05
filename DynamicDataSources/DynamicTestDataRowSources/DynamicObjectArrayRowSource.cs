// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources.ConcreteDataSources;

public abstract class DynamicObjectArrayRowSource(ArgsCode argsCode)
: DynamicDataSourceBase<object?[]>(argsCode)
{
    protected override ITestDataRow<TTestData, object?[]> CreateTestDataRow<TTestData>(
        TTestData testData,
        bool? withExpected)
    => new TestDataRow<TTestData>(
        testData,
        ArgsCode,
        withExpected);

    protected override void InitTestDataCollection<TTestData>(
        TTestData testData,
        bool? withExpected)
    => TestDataRowCollecttion = new TestDataRowCollection<TTestData>(
        testData,
        ArgsCode,
        withExpected);
}
