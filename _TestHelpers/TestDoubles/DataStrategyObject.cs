using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public sealed class DataStrategyObject(ArgsCode argsCode, bool? withExpected) : IDataStrategy
{
    public ArgsCode ArgsCode { get; } = argsCode;
    public bool? WithExpected { get; } = withExpected;
}
