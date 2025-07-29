// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataStrategyTypes;
public sealed record DataStrategy : IDataStrategy
{
    private DataStrategy(ArgsCode argsCode, PropertyCode propertyCode)
    {
        ArgsCode = argsCode;
        PropertyCode = propertyCode;
    }

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

    public bool Equals(IDataStrategy? other)
    => other is not null &&
        ArgsCode == other.ArgsCode &&
        PropertyCode == other.PropertyCode;

    public override sealed int GetHashCode()
    => HashCode.Combine(ArgsCode, PropertyCode);

    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode? argsCode,
        IDataStrategy? dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        return argsCode.HasValue && argsCode.Value != dataStrategy.ArgsCode ?
            GetStoredDataStrategy(argsCode.Value, dataStrategy.PropertyCode)
            : DataStrategies.First(dataStrategy.Equals);
    }

    public static IDataStrategy GetStoredDataStrategy(
        ArgsCode argsCode,
        PropertyCode propertyCode)
    => DataStrategies.First(x =>
        x.ArgsCode == argsCode.Defined(nameof(argsCode)) &&
        x.PropertyCode == propertyCode.Defined(nameof(propertyCode)));

    public static IDataStrategy GetStoredDataStrategy(IDataStrategy dataStrategy)
    {
        ArgumentNullException.ThrowIfNull(dataStrategy, nameof(dataStrategy));

        return DataStrategies.First(dataStrategy.Equals);
    }
}