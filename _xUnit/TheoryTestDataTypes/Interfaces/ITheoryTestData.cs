// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

/// <summary>
/// Represents a contract for providing test data for parameterized unit tests.
/// </summary>
/// <remarks>Implement this interface to supply data for theories in unit testing frameworks, such as xUnit. The
/// data provided by implementations of this interface is typically used to test a method or class with multiple sets of
/// input values.</remarks>
public interface ITheoryTestData;

/// <summary>
/// Represents a collection of test data for use in theory-based tests.
/// </summary>
/// <typeparam name="TTestData">The type of test data contained in the collection. Must implement <see cref="ITestData"/>.</typeparam>
public interface ITheoryTestData<TTestData>
: ITheoryTestData
where TTestData : ITestData
{
    /// <summary>
    /// Adds a test data item to the collection.
    /// </summary>
    /// <remarks>This method appends the specified test data item to the collection. Ensure that the 
    /// <paramref name="testData"/> parameter is properly initialized before calling this method.</remarks>
    /// <param name="testData">The test data item to add. Cannot be null.</param>
    void AddTestData(TTestData testData);
}
