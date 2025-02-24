namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

/// <summary>
/// Represents a sealed class that inherits from <see cref="DynamicDataSource"/> and is initialized with an <see cref="ArgsCode"/>.
/// </summary>
/// <param name="argsCode">The argument code used to initialize the base class.</param>
public sealed class DynamicDataSourceChild(ArgsCode argsCode) : DynamicDataSource(argsCode);
