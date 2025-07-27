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
        dataStrategy.PropertyCode);

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
/// Abstract base class for a strongly-typed test data row that associates a specific test data type (TTestData)
/// with a target row type (TRow). Inherits from <see cref="TestDataRow{TRow}"/> and implements
/// <see cref="ITestDataRow{TRow, TTestData}"/>.
/// </summary>
/// <typeparam name="TRow">The target type this test data row will be converted to</typeparam>
/// <typeparam name="TTestData">The specific type of test data this row contains, which must be non-null and implement ITestData</typeparam>
/// <param name="testData">The test data instance to associate with this row</param>
public abstract class TestDataRow<TRow, TTestData>(TTestData testData)
: TestDataRow<TRow>,
ITestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Gets the strongly-typed test data associated with this row.
    /// Initialized through the primary constructor.
    /// </summary>
    public TTestData TestData { get; init; } = testData;

    /// <summary>
    /// Gets the test data associated with this row as an <see cref="ITestData"/>.
    /// This sealed implementation always returns the strongly-typed <see cref="TestData"/> property.
    /// </summary>
    /// <returns>The test data instance associated with this row</returns>
    public override sealed ITestData GetTestData()
    => TestData;
}