// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders;

/// <summary>
/// Represents a row of test data, including the test data itself, argument codes, and an optional expected value
/// indicator.
/// </summary>
/// <remarks>
/// <para>This class is used to encapsulate test data and its associated metadata, such as argument codes and
/// whether the test data includes an expected value.</para>
/// <para>This primary constructor nitializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified <see cref="ITestData"/> instance and
/// <see cref="TestDataTypes.ArgsCode"/> enum.</para>
/// </remarks>
/// <typeparam name="TTestData">The type of the test data. Must implement <see cref="ITestData"/>.</typeparam>
/// <param name="testData">The test data associated with this row. Must implement <see cref="IExpected"/> if the third parameter is to be
/// set to true.</param>
/// <param name="argsCode">The code representing the arguments for this test data row.</param>
/// <param name="withExpected">A boolean value indicating whether to include expected values in the resulting parameter array. <see
/// langword="true"/> to include expected values; otherwise, <see langword="false"/>.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is null.</exception>
/// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> has invalid value.</exception>
public abstract class TestDataRow<TTestData, TRow>(
    IDataStrategy dataStrategy,
    TTestData testData)
: ITestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    private readonly TTestData _testData = testData;

    /// <inheritdoc cref="ITestDataRow.GetParameters"/>
    public object?[] Params
    => DataStrategy.WithExpected.HasValue ?
        _testData.ToParams(DataStrategy.ArgsCode, DataStrategy.WithExpected.Value)
        : _testData.ToArgs(DataStrategy.ArgsCode);

    public string? GetDisplayName(string? testMethodName)
    => TestData.GetDisplayName(testMethodName, TestCaseName);

    public string TestCaseName
    => _testData.TestCaseName;

    public IDataStrategy DataStrategy { get; init; } = dataStrategy
        ?? throw new ArgumentNullException(nameof(dataStrategy));

    public TTestData GetTestData()
    => _testData;

    public bool Equals(ITestCaseName? other)
    => other?.TestCaseName == TestCaseName;

    public override bool Equals(object? obj)
    => obj is ITestCaseName testCaseName
        && Equals(testCaseName);

    public override int GetHashCode()
    => TestCaseName.GetHashCode();

    public abstract TRow Convert();
    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        IDataStrategy dataStrategy,
        TTestData testData);
}

public sealed class TestDataRow<TTestData>(
    IDataStrategy dataStrategy,
    TTestData testData)
: TestDataRow<TTestData, object?[]>(
    dataStrategy,
    testData)
where TTestData : notnull, ITestData
{
    public override object?[] Convert()
    => Params;

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        IDataStrategy dataStrategy,
        TTestData testData)
    => new TestDataRow<TTestData>(
        dataStrategy,
        testData);
}
