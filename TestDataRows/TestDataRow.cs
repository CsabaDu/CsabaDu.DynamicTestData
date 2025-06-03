// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

/// <summary>
/// Provides extension methods for converting test data into <see cref="TestDataRow{TTestData}"/> instances.
/// </summary>
/// <remarks>These methods simplify the creation of <see cref="TestDataRow{TTestData}"/> objects by wrapping test
/// data and associated metadata, such as argument codes and expected result flags.</remarks>
public static class TestDataRow
{
    /// <summary>
    /// <inheritdoc cref="ToTestDataRow{TTestData}(TTestData, ArgsCode)"/>
    /// <param name="withExpected">A boolean value indicating whether the resulting <see cref="TestDataRow{TTestData}"/> should include the
    /// expected result.</param>
    public static TestDataRow<TTestData> ToTestDataRow<TTestData>(
        this TTestData testData,
        ArgsCode argsCode,
        bool withExpected)
    where TTestData : notnull, ITestData
    => new(
        testData,
        argsCode,
        withExpected);

    /// <summary>
    /// Converts the specified test data into a <see cref="TestDataRow{TTestData}"/> instance.
    /// </summary>
    /// <typeparam name="TTestData">The type of the test data. Must implement <see cref="ITestData"/> and cannot be null.</typeparam>
    /// <param name="testData">The test data to be converted. This parameter must not be null.</param>
    /// <param name="argsCode">The <see cref="ArgsCode"/> associated with the test data.</param>
    /// <returns>A new <see cref="TestDataRow{TTestData}"/> instance containing the specified test data and <paramref
    /// name="argsCode"/>.</returns>
    public static TestDataRow<TTestData> ToTestDataRow<TTestData>(
        this TTestData testData,
        ArgsCode argsCode)
    where TTestData : notnull, ITestData
    => new(
        testData,
        argsCode);
}

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
public class TestDataRow<TTestData>(
    TTestData testData,
    ArgsCode argsCode,
    bool withExpected)
: ITestDataRow
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestDataRow{TTestData}"/> class with the specified <see cref="ITestData"/> instance and
    /// <see cref="TestDataTypes.ArgsCode"/> enum.
    /// </summary>
    /// <param name="testData">The test data associated with this row. Must implement <see cref="IExpected"/> if the third parameter is to be
    /// set to true.</param>
    /// <param name="argsCode">The code representing the arguments for this test data row.</param>
    /// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> has invalid value.</exception>
    public TestDataRow(
        TTestData testData,
        ArgsCode argsCode)
    : this(
        testData,
        argsCode,
        testData is IExpected)
    {
    }

    [NotNull]
    private readonly bool _withExpected = withExpected;
    private readonly TTestData _testData = testData
        ?? throw new ArgumentNullException(nameof(testData));
    private object?[] _data = [];

    /// <inheritdoc cref="ITestDataRow.GetParameters"/>
    public object?[] Params
    => _testData.ToParams(
        ArgsCode,
        _withExpected);

    /// <inheritdoc cref="ITestDataRow.ArgsCode"/>
    public ArgsCode ArgsCode { get; init; } =
        argsCode.Defined(nameof(argsCode));
}
