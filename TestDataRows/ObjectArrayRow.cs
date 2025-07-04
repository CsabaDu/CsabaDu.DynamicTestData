// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

/// <summary>
/// Represents a test data row that uses an array of objects as its data structure.
/// </summary>
/// <remarks>This class provides functionality to convert test data into an array of objects and to create new
/// instances of  <see cref="ObjectArrayRow{TTestData}"/> with specified test data.</remarks>
/// <typeparam name="TTestData">The type of the test data associated with the row. Must be non-null and implement <see cref="ITestData"/>.</typeparam>
/// <param name="testData"></param>
public class ObjectArrayRow<TTestData>(TTestData testData)
: TestDataRow<object?[], TTestData>(testData)
where TTestData : notnull, ITestData
{
    public override object?[] Convert(IDataStrategy dataStrategy)
    => GetParams(dataStrategy);

    public override ITestDataRow<object?[], TTestData> CreateTestDataRow(
        TTestData testData)
    => new ObjectArrayRow<TTestData>(
        testData);
}
