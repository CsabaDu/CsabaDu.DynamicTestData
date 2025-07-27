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
    private DataStrategy(ArgsCode argsCode, PropertyCode propertyCode)
    {
        ArgsCode = argsCode;
        PropertyCode = propertyCode;
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
        DataStrategies = [];

        var argsCodes = Enum.GetValues<ArgsCode>();
        var propertyCodes = Enum.GetValues<PropertyCode>();

        foreach (var argsCode in argsCodes)
        {
            foreach (var propertyCode in propertyCodes)
            {
                DataStrategies.Add(new(argsCode, propertyCode));
            }
        }
    }

    private static readonly HashSet<DataStrategy> DataStrategies;

    /// <inheritdoc/>
    public ArgsCode ArgsCode { get; init; }

    /// <inheritdoc/>
    public PropertyCode PropertyCode { get; init; }

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
           PropertyCode == other.PropertyCode;

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    /// <remarks>
    /// The hash code is computed based on the combination of <see cref="ArgsCode"/>
    /// and <see cref="WithExpected"/> values.
    /// </remarks>
    public override sealed int GetHashCode()
        => HashCode.Combine(ArgsCode, PropertyCode);

    /// <summary>
    /// Retrieves a stored data strategy instance matching the specified criteria.
    /// </summary>
    /// <param name="argsCode">The argument conversion code to match (nullable).</param>
    /// <param name="dataStrategy">The strategy providing default values when argsCode is null.</param>
    /// <returns>
    /// A stored <see cref="IDataStrategy"/> instance matching either:
    /// <list type="bullet">
    ///   <item><description>The specified argsCode and the PropertyCode value from dataStrategy when argsCode has value</description></item>
    ///   <item><description>The complete dataStrategy when argsCode is null</description></item>
    /// </list>
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no matching strategy is found in the stored collection.
    /// </exception>
    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode? argsCode,
        IDataStrategy? dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        return argsCode.HasValue && argsCode.Value != dataStrategy.ArgsCode ?
            GetStoredDataStrategy(argsCode.Value, dataStrategy.PropertyCode)
            : DataStrategies.First(dataStrategy.Equals);
    }

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
        PropertyCode propertyCode)
    => DataStrategies.First(x =>
        x.ArgsCode == argsCode.Defined(nameof(argsCode)) &&
        x.PropertyCode == propertyCode.Defined(nameof(propertyCode)));
}