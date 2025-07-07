// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes;

/// <summary>
/// Represents a data strategy with associated arguments and an optional expected value indicator.
/// </summary>
/// <remarks>This type is immutable and implements <see cref="IDataStrategy"/>. It provides a mechanism to define
/// a strategy based on the specified <see cref="ArgsCode"/> and an optional flag indicating whether an expected value
/// is associated with the strategy.</remarks>
/// <param name="ArgsCode">The arguments code that defines the strategy. This value must not be null.</param>
/// <param name="WithExpected">An optional flag indicating whether the strategy includes an expected value.  If <see langword="null"/>, the
/// expected value is unspecified.</param>
public sealed class DataStrategy
: IDataStrategy
{
    private DataStrategy(
        ArgsCode argsCode,
        bool? withExpected)
    {
        ArgsCode = argsCode;
        WithExpected = withExpected;
    }
        
    static DataStrategy()
    {
        var argsCodes = Enum.GetValues<ArgsCode>();

        foreach (var argsCode in argsCodes)
        {
            DataStrategies.Add(new DataStrategy(argsCode, null));
            DataStrategies.Add(new DataStrategy(argsCode, false));
            DataStrategies.Add(new DataStrategy(argsCode, true));
        }
    }

    private static readonly HashSet<IDataStrategy> DataStrategies = [];

    public bool? WithExpected { get; init; }

    public ArgsCode ArgsCode { get; init; }

    public bool Equals(IDataStrategy? other)
    => other is not null &&
        ArgsCode == other.ArgsCode &&
        WithExpected == other.WithExpected;

    public override bool Equals(object? obj)
    =>  obj is IDataStrategy other
        && Equals(other);

    public override int GetHashCode()
    => HashCode.Combine(ArgsCode, WithExpected);

    public static IDataStrategy GetStoredDataStrategy(ArgsCode argsCode, bool? withExpected)
    => DataStrategies.Where(
            x => x.ArgsCode == argsCode
            && x.WithExpected == withExpected)
        .First();
}
