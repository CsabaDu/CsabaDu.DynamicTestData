// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataRows.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataRows;

/// <summary>
/// Abstract base class for test data rows that can be converted to a target type.
/// </summary>
/// <typeparam name="TRow">The type to convert this test data into (typically a DTO or domain model).</typeparam>
/// <remarks>
/// <para>
/// Provides core functionality for:
/// <list type="bullet">
///   <item>Test parameter generation</item>
///   <item>Test case identification</item>
///   <item>Type conversion infrastructure</item>
/// </list>
/// </para>
/// <para>
/// Implements <see cref="ITestDataRow{TRow}"/> while delegating to concrete implementations
/// for type-specific conversion logic.
/// </para>
/// </remarks>
public abstract class TestDataRow<TRow>
: NamedTestCase,
ITestDataRow<TRow>
{
    public override sealed string TestCaseName
    => GetTestData().TestCaseName;

    /// <summary>
    /// Gets the parameter values for this test data row using the given <see cref="IDataStrategy"/> parameter.
    /// </summary>
    /// <param name="dataStrategy">
    /// Determines which parameters to include and their format.
    /// </param>
    /// <returns>
    /// Array of parameter values ready for test execution.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dataStrategy"/> is null.
    /// </exception>
    public object?[] GetParams(IDataStrategy dataStrategy)
    => GetTestData().ToParams(
        dataStrategy?.ArgsCode
            ?? throw new ArgumentNullException(nameof(dataStrategy)),
        dataStrategy.PropsCode);

    #region Abstract methods
    /// <summary>
    /// Converts this test data to the target type using the specified strategy.
    /// </summary>
    /// <param name="dataStrategy">
    /// Controls how test data properties are mapped during conversion.
    /// </param>
    /// <returns>
    /// A new instance of <typeparamref name="TRow"/> populated with test data.
    /// </returns>
    public abstract TRow Convert(IDataStrategy dataStrategy);

    /// <summary>
    /// Gets the complete test data for this row.
    /// </summary>
    /// <returns>
    /// The underlying <see cref="ITestData"/> implementation containing all test parameters.
    /// </returns>
    public abstract ITestData GetTestData();
    #endregion
}

/// <summary>
/// Abstract base class for strongly-typed test data rows with associated typed test data.
/// </summary>
/// <typeparam name="TRow">
/// The target conversion type (typically a DTO or domain model).
/// </typeparam>
/// <typeparam name="TTestData">
/// The specific test data type (must implement <see cref="ITestData"/> and be non-nullable).
/// </typeparam>
/// <param name="testData">The test data instance to associate with this row.</param>
/// <remarks>
/// <para>
/// Extends <see cref="TestDataRow{TRow}"/> with:
/// <list type="bullet">
///   <item>Strongly-typed test data access</item>
///   <item>Constructor-based initialization</item>
///   <item>Sealed core functionality</item>
/// </list>
/// </para>
/// <para>
/// Serves as the foundation for concrete test row implementations with known test data types.
/// </para>
/// </remarks>
public abstract class TestDataRow<TRow, TTestData>(TTestData testData)
: TestDataRow<TRow>,
    ITestDataRow<TRow, TTestData>
where TTestData : notnull, ITestData
{
    /// <summary>
    /// Gets the strongly-typed test data instance.
    /// </summary>
    /// <value>
    /// The test data initialized through the constructor, providing type-safe access
    /// to all test parameters and expectations.
    /// </value>
    public TTestData TestData { get; init; } = testData;

    /// <summary>
    /// Gets the test data instance as an <see cref="ITestData"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="TestData"/> property value.
    /// </returns>
    /// <remarks>
    /// This sealed implementation ensures consistent behavior across all derived types.
    /// </remarks>
    public override sealed ITestData GetTestData()
    => TestData;
}