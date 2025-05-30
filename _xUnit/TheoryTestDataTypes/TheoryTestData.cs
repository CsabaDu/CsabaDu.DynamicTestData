// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes;

/// <summary>
/// Provides a container for test data used in parameterized unit tests,  supporting type validation and argument
/// matching.
/// </summary>
/// <remarks>This class extends <see cref="TheoryData"/> to include type information  for test arguments, enabling
/// validation of argument types and ensuring  compatibility with the expected test parameters. It is particularly 
/// useful for scenarios where test data must conform to specific type  constraints.</remarks>
public class TheoryTestData
: TheoryData, ITheoryTestData, IProperties
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheoryTestData"/> class with the specified types and arguments.
    /// </summary>
    /// <param name="types">An array of <see cref="Type"/> objects representing the types associated with the test data. Cannot be <see
    /// langword="null"/>.</param>
    /// <param name="args">An array of arguments to be added as a row of test data. Can be <see langword="null"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="types"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="args"/> is null.</exception>
    internal TheoryTestData(Type[] types, object?[] args)
    {
        Types = types
            ?? throw new ArgumentNullException(nameof(types));

        AddRow(args);
    }

    /// <inheritdoc cref="IProperties.Types"/>
    public IReadOnlyCollection<Type> Types { get; init; }

    /// <inheritdoc cref="IProperties.Add"/>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="args"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if the provided <paramref name="types"/> do not match the expected types.</exception>
    public void Add(Type[] types, object?[] args)
    {
        if (Equals(types))
        {
            AddRow(args);
            return;
        }

        throw new ArgumentException(
            "Types do not match.", nameof(types));
    }

    /// <summary>
    /// Determines whether the <see cref="Types"/> property of the current instance is
    /// equal to the specified array of <see cref="Type"/> objects.
    /// </summary>
    /// <param name="other">An array of <see cref="Type"/> objects to compare with the current instance.
    /// Can be <see langword="null"/>.</param>
    /// <returns>
    /// <see langword="true"/> if the specified array is not <see langword="null"/> and contains the same sequence of
    /// <see cref="Type"/> objects as the current instance; otherwise, <see langword="false"/>.</returns>
    public bool Equals(Type[]? other)
    => other is not null
        && other.SequenceEqual(Types);
}

/// <summary>
/// Provides a strongly-typed container for test data used in xUnit theory tests.
/// </summary>
/// <remarks>This class extends <see cref="TheoryData"/> to allow adding test data of a specific type and ensures
/// type safety by restricting the data to the specified generic type <typeparamref name="TTestData"/>.</remarks>
/// <typeparam name="TTestData">The type of test data contained in this instance. Must implement <see cref="ITestData"/>.</typeparam>
public class TheoryTestData<TTestData>
: TheoryData<TTestData>, ITheoryTestData
where TTestData : ITestData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheoryTestData{T}"/> class with the specified test data.
    /// </summary>
    /// <param name="testData">The test data to be added as a row to the collection.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is null.</exception>
    internal TheoryTestData(TTestData testData)
    => Add(testData);
}

