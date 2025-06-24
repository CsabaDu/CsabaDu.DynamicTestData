// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

public abstract class TestDataRow<TRow>
: ITestDataRow<TRow>
{
    public object?[] GetParams(IDataStrategy dataStrategy)
    => GetTestData().ToParams(
        dataStrategy.ArgsCode,
        dataStrategy.WithExpected);

    public string GetTestCaseName()
    => GetTestData().GetTestCaseName();

    public bool Equals(INamedTestCase? other)
    => other?.GetTestCaseName() == GetTestCaseName();

    public override bool Equals(object? obj)
    => obj is INamedTestCase other
        && Equals(other);

    public override int GetHashCode()
    => GetTestCaseName().GetHashCode();

    #region Abstract methods
    public abstract TRow Convert(IDataStrategy dataStrategy);
    protected abstract ITestData GetTestData();
    #endregion
}

/// <summary>
/// Represents a row of test dataRows, including the test dataRows itself, argument codes, and an optional expected value
/// indicator.
/// </summary>
/// <remarks>
/// <para>This class is used to encapsulate test dataRows and its associated metadata, such as argument codes and
/// whether the test dataRows includes an expected value.</para>
/// <para>This primary constructor nitializes a new instance of the <see cref="ObjectArrayRow{TTestData}"/> class with the specified <see cref="ITestData"/> instance and
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
: TestDataRow<TRow>, ITestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
{
    public TTestData TestData {  get; init; } = testData;

    protected override sealed ITestData GetTestData()
    => TestData;

    #region Abstract methods
    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData);
    #endregion
}
