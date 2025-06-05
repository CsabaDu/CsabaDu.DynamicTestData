// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)


namespace CsabaDu.DynamicTestData.TestDataRows;

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
    ArgsCode argsCode,
    bool? withExpected)
: ITestDataRow<TTestData, TRow>
where TTestData : notnull, ITestData
where TRow : notnull
{
    private readonly TTestData _testData = testData;
    private readonly bool? _withExpected = withExpected;

    /// <inheritdoc cref="ITestDataRow.GetParameters"/>
    public object?[] Params
    => _withExpected.HasValue ?
        _testData.ToParams(
            ArgsCode,
            _withExpected.Value)
            : _testData.ToArgs(ArgsCode);

    /// <inheritdoc cref="ITestDataRow.ArgsCode"/>
    public ArgsCode ArgsCode { get; init; } =
        argsCode.Defined(nameof(argsCode));

    public Type TestDataType
    => typeof(TTestData);

    public string TestCaseName
    => _testData.TestCaseName;

    public List<TRow> Add(List<TRow> dataRowList)
    => [.. dataRowList, Convert()];

    public abstract TRow Convert();

    public bool Equals(ITestDataType? other)
    => other is not null
        && other.TestDataType == TestDataType;

    public bool Equals(ITestCaseName? other)
    => other is not null
        && other.TestCaseName == TestCaseName;
}

public sealed class TestDataRow<TTestData>(
    TTestData testData,
    ArgsCode argsCode,
    bool? withExpected)
: TestDataRow<TTestData, object?[]>(
    testData,
    argsCode,
    withExpected)
where TTestData : notnull, ITestData
{
    public override object?[] Convert()
    => Params;
}
