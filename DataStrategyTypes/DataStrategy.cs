// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes;

/// <summary>
/// A sealed record implementation of <see cref="IDataStrategy"/> that strictly follows the Flyweight pattern,
/// providing a shared set of predefined, immutable strategy instances.
/// </summary>
/// <remarks>
/// <para>
/// <strong>Flyweight Pattern Enforcement:</strong> The private constructor ensures all instances are created
/// during static initialization and accessed through the <see cref="GetStoredDataStrategy"/> methods,
/// guaranteeing optimal memory usage.
/// </para>
/// <para>
/// <strong>Thread Safety:</strong> This type is inherently thread-safe because:
/// <list type="bullet">
/// <item>All instances are immutable (record with init-only properties)</item>
/// <item>The static collection is initialized once during type initialization</item>
/// <item>All public methods perform read-only operations on immutable data</item>
/// </list>
/// </para>
/// <para>
/// Instead of creating new instances, clients must retrieve existing ones through the
/// <see cref="GetStoredDataStrategy"/> methods, ensuring efficient memory usage when the same
/// strategies are needed repeatedly.
/// </para>
/// </remarks>
public sealed record DataStrategy : IDataStrategy
{
    // Private constructor maintains Flyweight pattern integrity
    private DataStrategy(ArgsCode argsCode, PropsCode propsCode)
    {
        ArgsCode = argsCode;
        PropsCode = propsCode;
    }

    static DataStrategy()
    {
        DataStrategies = [];

        foreach (var argsCode in Enum.GetValues<ArgsCode>())
        {
            foreach (var propsCode in Enum.GetValues<PropsCode>())
            {
                DataStrategies.Add(new(argsCode, propsCode));
            }
        }
    }

    /// <summary>
    /// The static collection containing all possible Flyweight instances of <see cref="DataStrategy"/>.
    /// </summary>
    private static readonly HashSet<DataStrategy> DataStrategies;

    /// <inheritdoc/>
    public ArgsCode ArgsCode { get; init; }

    /// <inheritdoc/>
    public PropsCode PropsCode { get; init; }

    /// <summary>
    /// Determines whether the specified <see cref="IDataStrategy"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">The strategy to compare with the current instance.</param>
    /// <returns>
    /// <see langword="true"/> if the specified strategy has the same <see cref="Statics.ArgsCode"/>
    /// and <see cref="Statics.PropsCode"/> values; otherwise, <see langword="false"/>.
    /// </returns>
    public bool Equals(IDataStrategy? other)
    => other is not null &&
        ArgsCode == other.ArgsCode &&
        PropsCode == other.PropsCode;

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override sealed int GetHashCode()
    => HashCode.Combine(ArgsCode, PropsCode);

    /// <summary>
    /// Retrieves a shared Flyweight instance based on the provided arguments, with optional
    /// override of the <see cref="ArgsCode"/>.
    /// </summary>
    /// <param name="argsCode">The optional argument code to use instead of the strategy's default.</param>
    /// <param name="dataStrategy">The base data strategy to match against.</param>
    /// <returns>The shared <see cref="IDataStrategy"/> Flyweight instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dataStrategy"/> is <see langword="null"/>.
    /// </exception>
    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode? argsCode,
        IDataStrategy? dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        return argsCode.HasValue && argsCode.Value != dataStrategy.ArgsCode ?
            GetStoredDataStrategy(argsCode.Value, dataStrategy.PropsCode)
            : DataStrategies.First(dataStrategy.Equals);
    }

    /// <summary>
    /// Retrieves a shared Flyweight instance based on explicit <see cref="Statics.ArgsCode"/>
    /// and <see cref="Statics.PropsCode"/> values.
    /// </summary>
    /// <param name="argsCode">The argument code for the desired strategy.</param>
    /// <param name="propsCode">The property code for the desired strategy.</param>
    /// <returns>The shared <see cref="IDataStrategy"/> Flyweight instance.</returns>
    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode argsCode,
        PropsCode propsCode)
    => DataStrategies.First(ds =>
        ds.ArgsCode == argsCode.Defined(nameof(argsCode)) &&
        ds.PropsCode == propsCode.Defined(nameof(propsCode)));

    /// <summary>
    /// Retrieves a shared Flyweight instance that matches the provided strategy.
    /// </summary>
    /// <param name="dataStrategy">The strategy to match against the stored instances.</param>
    /// <returns>The shared <see cref="IDataStrategy"/> Flyweight instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dataStrategy"/> is <see langword="null"/>.
    /// </exception>
    public static IDataStrategy GetStoredDataStrategy(IDataStrategy dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        return DataStrategies.First(dataStrategy.Equals);
    }
}