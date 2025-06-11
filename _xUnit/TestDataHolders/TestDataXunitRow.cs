// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TestDataHolders;

public sealed class TestDataXunitRow<TTestData>(
    TTestData testData,
    ArgsCode argsCode)
: TestDataRow<TTestData, object?[]>(
    testData,
    new DataStrategy(
        argsCode,
        IsExpected(testData))),
ITestDataXunitRow
where TTestData : notnull, ITestData
{
    public TestDataXunitRow(TTestData testData,
    IDataStrategy? dataStrategy)
    : this(testData,
        dataStrategy?.ArgsCode ?? default)
    {
    }

    public override object?[] Convert()
    => Params;

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestDataXunitRow<TTestData>(
        testData,
        dataStrategy);
}