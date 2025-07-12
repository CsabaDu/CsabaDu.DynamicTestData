// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes;
/// <summary>
/// Represents an immutable implementation of <see cref="IDataStrategy"/> that provides
/// predefined strategy combinations for test data argument conversion.
/// </summary>
/// <remarks>
/// <para>
/// This sealed record type provides a flyweight pattern implementation of data strategies,
/// creating and storing all possible combinations of <see cref="ArgsCode"/> and 
/// <see cref="WithExpected"/> values during static initialization.
/// </para>
/// <para>
/// The type is designed to be:
/// </para>
/// <list type="bullet">
///   <item><description>Immutable - all properties are init-only</description></item>
///   <item><description>Thread-safe - static initialization happens once</description></item>
///   <item><description>Memory-efficient - reuses stored instances</description></item>
/// </list>
/// </remarks>
public sealed record DataStrategy : IDataStrategy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataStrategy"/> class.
    /// </summary>
    /// <param name="argsCode">The argument conversion code strategy.</param>
    /// <param name="withExpected">Determines if expected results should be included.</param>
    /// <remarks>
    /// This private constructor ensures all instances are created during static initialization
    /// and maintains control over instance creation.
    /// </remarks>
    private DataStrategy(ArgsCode argsCode, bool? withExpected)
    {
        ArgsCode = argsCode;
        WithExpected = withExpected;
    }

    /// <summary>
    /// Static constructor that initializes all possible <see cref="DataStrategy"/> combinations.
    /// </summary>
    /// <remarks>
    /// Creates all permutations of <see cref="ArgsCode"/> and <see cref="WithExpected"/> values
    /// (null, false, true) and stores them in a static collection for reuse.
    /// </remarks>
    static DataStrategy()
    {
        var argsCodes = Enum.GetValues<ArgsCode>();
        DataStrategies = [];

        foreach (var argsCode in argsCodes)
        {
            DataStrategies.Add(new DataStrategy(argsCode, null));
            DataStrategies.Add(new DataStrategy(argsCode, false));
            DataStrategies.Add(new DataStrategy(argsCode, true));
        }
    }

    private static readonly HashSet<IDataStrategy> DataStrategies;

    /// <inheritdoc/>
    public bool? WithExpected { get; init; }

    /// <inheritdoc/>
    public ArgsCode ArgsCode { get; init; }

    /// <summary>
    /// Determines whether the specified <see cref="IDataStrategy"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">The strategy to compare with the current instance.</param>
    /// <returns>
    /// <see langword="true"/> if the specified strategy has the same <see cref="ArgsCode"/> 
    /// and <see cref="WithExpected"/> values; otherwise, <see langword="false"/>.
    /// </returns>
    public bool Equals(IDataStrategy? other)
        => other is not null &&
           ArgsCode == other.ArgsCode &&
           WithExpected == other.WithExpected;

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    /// <remarks>
    /// The hash code is computed based on the combination of <see cref="ArgsCode"/>
    /// and <see cref="WithExpected"/> values.
    /// </remarks>
    public override sealed int GetHashCode()
        => HashCode.Combine(ArgsCode, WithExpected);

    /// <summary>
    /// Retrieves a stored data strategy instance matching the specified criteria.
    /// </summary>
    /// <param name="argsCode">The argument conversion code to match (nullable).</param>
    /// <param name="dataStrategy">The strategy providing default values when argsCode is null.</param>
    /// <returns>
    /// A stored <see cref="IDataStrategy"/> instance matching either:
    /// <list type="bullet">
    ///   <item><description>The specified argsCode and the WithExpected value from dataStrategy when argsCode has value</description></item>
    ///   <item><description>The complete dataStrategy when argsCode is null</description></item>
    /// </list>
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no matching strategy is found in the stored collection.
    /// </exception>
    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode? argsCode,
        IDataStrategy dataStrategy)
        => argsCode.HasValue ?
            GetStoredDataStrategy(argsCode.Value, dataStrategy.WithExpected) :
            DataStrategies.First(dataStrategy.Equals);

    /// <summary>
    /// Retrieves a stored data strategy instance matching the specified arguments.
    /// </summary>
    /// <param name="argsCode">The required argument conversion code.</param>
    /// <param name="withExpected">The required expected result inclusion flag.</param>
    /// <returns>
    /// A stored <see cref="IDataStrategy"/> instance matching both the specified
    /// <paramref name="argsCode"/> and <paramref name="withExpected"/> values.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no matching strategy is found in the stored collection.
    /// </exception>
    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode argsCode,
        bool? withExpected)
        => DataStrategies.First(x =>
            x.ArgsCode == argsCode.Defined(nameof(argsCode)) &&
            x.WithExpected == withExpected);
}