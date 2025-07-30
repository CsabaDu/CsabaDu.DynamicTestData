// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// Represents a dynamic data source that provides test data in the form of object arrays.
/// </summary>
/// <remarks>
/// This abstract class serves as a base for creating dynamic data sources that generate test data rows
/// containing arrays of objects. Derived classes can use this to provide parameterized test data
/// for unit tests. It inherits from <see cref="DynamicDataRowSource{object?[]}"/> and specializes
/// in handling object array data rows.
/// </remarks>
/// <param name="argsCode">The code representing the arguments to be used for test data generation.</param>
/// <param name="propertyCode">The code representing the property or expected result type for validation.</param>
public abstract class DynamicObjectArrayRowSource(ArgsCode argsCode, PropertyCode propertyCode)
    : DynamicDataRowSource<object?[]>(argsCode, propertyCode)
{
    /// <summary>
    /// Initializes the data holder with the specified test data instance.
    /// </summary>
    /// <typeparam name="TTestData">The type of the test data object.</typeparam>
    /// <param name="testData">The test data instance to be held.</param>
    /// <remarks>
    /// Creates a new <see cref="ObjectArrayRowHolder{TTestData}"/> instance to manage
    /// the test data and its association with this data source.
    /// </remarks>
    protected override void InitDataHolder<TTestData>(TTestData testData)
        => DataHolder = new ObjectArrayRowHolder<TTestData>(testData, this);
}