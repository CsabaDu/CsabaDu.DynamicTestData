// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

/// <summary>
/// Represents a collection of properties associated with test data,  providing functionality to manage and compare
/// property types.
/// </summary>
/// <remarks>This interface is designed to handle property types and their associated arguments  in the context of
/// test data. It also supports equality comparison based on the  property types.</remarks>
public interface IProperties : ITheoryTestData, IEquatable<Type[]>
{
    /// <summary>
    /// Gets the array of types associated with the current instance.
    /// </summary>
    Type[] Types { get; }

    /// <summary>
    /// Adds a set of types and their corresponding arguments to the collection.
    /// </summary>
    /// <param name="types">An array of <see cref="Type"/> objects representing the types to add. Cannot be null or empty.</param>
    /// <param name="args">An array of arguments corresponding to the types. The length must match the <paramref name="types"/> array. Can
    /// contain null values.</param>
    void Add(Type[] types, object?[] args);
}
