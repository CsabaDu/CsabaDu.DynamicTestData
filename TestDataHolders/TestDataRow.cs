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
    TTestData testData,
    IDataStrategy? dataStrategy)
: ITestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
{
    public string TestCaseName
    => TestData.TestCaseName;

    public TTestData TestData {  get; init; } = testData;

    public object?[] Params
    => TestData.ToParams(
        DataStrategy.ArgsCode,
        DataStrategy.WithExpected);

    public IDataStrategy DataStrategy { get; init; } = dataStrategy ?? DataStrategy<TTestData>.Default;


    public bool Equals(ITestCaseName? other)
    => other?.TestCaseName == TestCaseName;

    public override bool Equals(object? obj)
    => obj is ITestCaseName other
        && Equals(other);

    public override int GetHashCode()
    => TestCaseName.GetHashCode();

    public abstract TRow Convert();

    public abstract ITestDataRow<TTestData, TRow> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy);
}

public sealed class TestDataRow<TTestData>
: TestDataRow<TTestData, object?[]>
where TTestData : notnull, ITestData
{
    internal TestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    : base(testData,
        dataStrategy)
    {
    }

    //internal TestDataRow(
    //    TTestData testData,
    //    ArgsCode argsCode,
    //    bool? withExpected)
    //: base(testData)
    //{
    //    DataStrategy =
    //        new DataStrategy<TTestData>(
    //            argsCode,
    //            withExpected);
    //}

    public override object?[] Convert()
    => Params;

    public override ITestDataRow<TTestData, object?[]> CreateTestDataRow(
        TTestData testData,
        IDataStrategy? dataStrategy)
    => new TestDataRow<TTestData>(
        testData,
        dataStrategy);
}
