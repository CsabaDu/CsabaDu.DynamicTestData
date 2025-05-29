// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

/// <summary>
/// Represents an instance of test data that can be extended with additional test data.
/// </summary>
/// <remarks>This interface is used to manage and aggregate test data for theory-based testing scenarios. It
/// provides a method to add new test data to the instance.</remarks>
/// <typeparam name="T">The type of test data. Must implement <see cref="ITestData"/>.</typeparam>
public interface IInstance<T> : ITheoryTestData
where T : ITestData
{
    /// <summary>
    /// Adds the specified test data to the collection.
    /// </summary>
    /// <param name="testData">The test data to add. Cannot be null.</param>
    /// <typeparam name="T">The type of test data. Must implement <see cref="ITestData"/>.</typeparam>
    void Add(T testData);
}