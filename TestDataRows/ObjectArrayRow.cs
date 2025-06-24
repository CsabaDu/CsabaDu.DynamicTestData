// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

public class ObjectArrayRow<TTestData>(TTestData testData)
: TestDataRow<TTestData, object?[]>(testData)
where TTestData : notnull, ITestData
{
    public override object?[] Convert(IDataStrategy dataStrategy)
    => GetParams(dataStrategy);

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData)
    => new ObjectArrayRow<TTestData>(
        testData);
}
