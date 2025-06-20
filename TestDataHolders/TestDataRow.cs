// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

/// <summary>
/// Represents a row of test dataRows, including the test dataRows itself, argument codes, and an optional expected value
/// indicator.
/// </summary>
/// <remarks>
/// <para>This class is used to encapsulate test dataRows and its associated metadata, such as argument codes and
/// whether the test dataRows includes an expected value.</para>
/// <para>This primary constructor nitializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified <see cref="ITestData"/> instance and
/// <see cref="TestDataTypes.ArgsCode"/> enum.</para>
/// </remarks>
/// <typeparam name="TTestData">The type of the test dataRows. Must implement <see cref="ITestData"/>.</typeparam>
/// <param name="testData">The test dataRows associated with this row. Must implement <see cref="IExpected"/> if the third parameter is to be
/// set to true.</param>
/// <param name="argsCode">The code representing the arguments for this test dataRows row.</param>
/// <param name="withExpected">A boolean value indicating whether to include expected values in the resulting parameter array. <see
/// langword="true"/> to include expected values; otherwise, <see langword="false"/>.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is null.</exception>
/// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> has invalid value.</exception>
public abstract class TestDataRow<TTestData, TRow>(
    TTestData testData)
: ITestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
{
    public string GetTestCaseName()
    => TestData.GetTestCaseName();

    public TTestData TestData {  get; init; } = testData;

    protected object?[] GetParams(IDataStrategy dataStrategy)
    => TestData.ToParams(
        dataStrategy.ArgsCode,
        dataStrategy.WithExpected);

    public bool Equals(INamedTestCase? other)
    => other?.GetTestCaseName() == GetTestCaseName();

    public override bool Equals(object? obj)
    => obj is INamedTestCase other
        && Equals(other);

    public override int GetHashCode()
    => GetTestCaseName().GetHashCode();

    public abstract TRow Convert(IDataStrategy dataStrategy);

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData);
}

public class TestDataRow<TTestData>(TTestData testData)
: TestDataRow<TTestData, object?[]>(testData)
where TTestData : notnull, ITestData
{
    public override object?[] Convert(IDataStrategy dataStrategy)
    => GetParams(dataStrategy);

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData)
    => new TestDataRow<TTestData>(
        testData);
}
