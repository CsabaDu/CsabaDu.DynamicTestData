// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows;

/// <summary>
/// Abstract base class representing a test data row that can be converted to a specific row type (TRow).
/// Implements interfaces for test data management and test case identification.
/// </summary>
/// <typeparam name="TRow">The target type this test data row will be converted to</typeparam>
public abstract class TestDataRow<TRow>
    : ITestDataRow<TRow>
{
    /// <summary>
    /// Gets the parameters for this test data row using the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use for parameter conversion</param>
    /// <returns>An array of parameters for the test case</returns>
    /// <exception cref="ArgumentNullException">Thrown if dataStrategy is null</exception>
    public object?[] GetParams(IDataStrategy dataStrategy)
        => GetTestData().ToParams(
            dataStrategy?.ArgsCode
                ?? throw new ArgumentNullException(nameof(dataStrategy)),
            dataStrategy.WithExpected);

    /// <summary>
    /// Gets the name of this test case, derived from the underlying test data.
    /// </summary>
    /// <returns>The test case name as a string</returns>
    public string GetTestCaseName()
        => GetTestData().GetTestCaseName();

    /// <summary>
    /// Compares this test data row with another INamedTestCase for equality based on test case names.
    /// </summary>
    /// <param name="other">The other test case to compare with</param>
    /// <returns>True if the test cases have the same name, false otherwise</returns>
    public bool Equals(INamedTestCase? other)
        => other?.GetTestCaseName() == GetTestCaseName();

    /// <summary>
    /// Compares this test data row with another object for equality.
    /// </summary>
    /// <param name="obj">The object to compare with</param>
    /// <returns>True if the object is an INamedTestCase with the same name, false otherwise</returns>
    public override sealed bool Equals(object? obj)
        => obj is INamedTestCase other
            && Equals(other);

    /// <summary>
    /// Gets the hash code of the value returned by the <see cref="GetTestCaseName()" /> method.
    /// </summary>
    /// <returns>Hash code of the test case name</returns>
    public override sealed int GetHashCode()
        => GetTestCaseName().GetHashCode();

    #region Abstract methods
    /// <summary>
    /// Converts this test data row to the target TRow type using the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy to use for conversion</param>
    /// <returns>The converted row of type TRow</returns>
    public abstract TRow Convert(IDataStrategy dataStrategy);

    /// <summary>
    /// Gets the underlying test data for this row.
    /// </summary>
    /// <returns>An ITestData implementation containing the test data</returns>
    public abstract ITestData GetTestData();
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
/// <see cref="Statics.ArgsCode"/> enum.</para>
/// </remarks>
/// <typeparam name="TTestData">The type of the test dataRows. Must implement <see cref="ITestData"/>.</typeparam>
/// <param name="testData">The test dataRows associated with this row. Must implement <see cref="IExpected"/> if the third parameter is to be
/// set to true.</param>
/// <param name="argsCode">The code representing the arguments for this test dataRows row.</param>
/// <param name="withExpected">A boolean value indicating whether to include expected values in the resulting parameter array. <see
/// langword="true"/> to include expected values; otherwise, <see langword="false"/>.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is null.</exception>
/// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> has invalid value.</exception>
public abstract class TestDataRow<TRow, TTestData>(TTestData testData)
: TestDataRow<TRow>, ITestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    public TTestData TestData {  get; init; } = testData;

    public override sealed ITestData GetTestData()
    => TestData;
}
