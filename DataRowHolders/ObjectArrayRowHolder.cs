// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

/// <summary>
/// Specialized holder for test data that will be converted to parameter arrays for test execution.
/// </summary>
/// <typeparam name="TTestData">
/// The type of test data (must implement <see cref="ITestData"/> and be non-nullable).
/// </typeparam>
/// <remarks>
/// <para>
/// This implementation is optimized for test cases that require:
/// <list type="bullet">
///   <item>Direct parameter array access</item>
///   <item>Dynamic test execution</item>
///   <item>Untyped parameter passing</item>
/// </list>
/// </para>
/// <para>
/// Inherits from <see cref="DataRowHolder{object?[], TTestData}"/> to provide:
/// <list type="bullet">
///   <item>Automatic object array conversion</item>
///   <item>Strategy-based parameter formatting</item>
///   <item>Test data management</item>
/// </list>
/// </para>
/// </remarks>
public class ObjectArrayRowHolder<TTestData>
    : DataRowHolder<object?[], TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Initializes a new instance with test data and processing strategy.
    /// </summary>
    /// <param name="testData">The test data to manage.</param>
    /// <param name="dataStrategy">
    /// The strategy determining how test data is converted to parameter arrays.
    /// </param>
    public ObjectArrayRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
    : base(testData, dataStrategy)
    {
    }

    /// <summary>
    /// Initializes a new instance by copying from another holder with a new strategy.
    /// </summary>
    /// <param name="other">The source holder to copy test data from.</param>
    /// <param name="dataStrategy">The new conversion strategy to apply.</param>
    public ObjectArrayRowHolder(
        IDataRowHolder<object?[], TTestData> other,
        IDataStrategy dataStrategy)
    : base(other, dataStrategy)
    {
    }

    /// <summary>
    /// Creates a new test data row configured for object array conversion.
    /// </summary>
    /// <param name="testData">The test data to wrap.</param>
    /// <returns>
    /// A new <see cref="ObjectArrayRow{TTestData}"/> instance.
    /// </returns>
    public override ITestDataRow<object?[], TTestData> CreateTestDataRow(TTestData testData)
    => new ObjectArrayRow<TTestData>(testData);

    /// <summary>
    /// Gets this or creates a new holder instance with the specified processing strategy.
    /// </summary>
    /// <param name="dataStrategy">The desired processing strategy.</param>
    /// <returns>
    /// The current instance if strategies match, otherwise a new holder with the new strategy.
    /// </returns>
    /// <remarks>
    /// This implementation avoids unnecessary object creation when the requested strategy
    /// matches the current holder's strategy.
    /// </remarks>
    public override IDataRowHolder<object?[]> GetDataRowHolder(IDataStrategy dataStrategy)
    => dataStrategy == DataStrategy ? this : new ObjectArrayRowHolder<TTestData>(this, dataStrategy);
}