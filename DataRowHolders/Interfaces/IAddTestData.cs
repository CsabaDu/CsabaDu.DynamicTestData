// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

/// <summary>
/// Supports adding test data to collections.
/// </summary>
/// <typeparam name="TTestData">Test data type (non-nullable ITestData).</typeparam>
public interface IAddTestData<TTestData>
    where TTestData : notnull, ITestData
{
    /// <summary>
    /// Adds test data to the collection.
    /// </summary>
    /// <param name="testData">Data to add.</param>
    void Add(TTestData testData);

    void AddRange(IEnumerable<TTestData> testDataCollection);

    IEnumerable<TTestData> GetTestDataCollection();
}