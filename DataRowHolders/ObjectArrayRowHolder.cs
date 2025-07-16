// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders;

/// <summary>
/// A concrete implementation of <see cref="DataRowHolder{TRow, TTestData}"/> 
/// that holds test data rows to be converted to object arrays.
/// </summary>
/// <typeparam name="TTestData">
/// The type of test data which must implement <see cref="ITestData"/> and be non-nullable.
/// </typeparam>
/// <remarks>
/// This specialized holder manages test data that will ultimately be transformed into
/// object array format for dynamic test execution.
/// </remarks>
public class ObjectArrayRowHolder<TTestData>
    : DataRowHolder<object?[], TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Initializes a new instance with the specified test data and conversion strategy.
    /// </summary>
    /// <param name="testData">The source test data to be converted to object arrays.</param>
    /// <param name="dataStrategy">The conversion strategy to apply.</param>
    public ObjectArrayRowHolder(
        TTestData testData,
        IDataStrategy dataStrategy)
        : base(testData, dataStrategy)
    {
    }

    /// <summary>
    /// Initializes a new instance by cloning an existing holder with a new conversion strategy.
    /// </summary>
    /// <param name="other">The source data row holder to clone.</param>
    /// <param name="dataStrategy">The new conversion strategy to apply.</param>
    public ObjectArrayRowHolder(
        IDataRowHolder<object?[], TTestData> other,
        IDataStrategy dataStrategy)
        : base(other, dataStrategy)
    {
    }

    /// <summary>
    /// Creates a new test data row that will be converted to an object array.
    /// </summary>
    /// <param name="testData">The test data to convert.</param>
    /// <returns>A new row container ready for object array conversion.</returns>
    public override ITestDataRow<object?[], TTestData> CreateTestDataRow(
        TTestData testData)
        => new ObjectArrayRow<TTestData>(testData);

    /// <summary>
    /// Gets this or creates a new data row holder with the specified data strategy.
    /// </summary>
    /// <param name="dataStrategy">The data strategy for the new holder.</param>
    /// <returns>
    /// The current instance if the data strategy matches, 
    /// otherwise a new <see cref="ObjectArrayRowHolder{TTestData}"/> instance.
    /// </returns>
    public override IDataRowHolder<object?[]> GetDataRowHolder(
        IDataStrategy dataStrategy)
        => dataStrategy == DataStrategy
            ? this
            : new ObjectArrayRowHolder<TTestData>(this, dataStrategy);
}
