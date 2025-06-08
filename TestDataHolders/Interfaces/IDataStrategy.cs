namespace CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

public interface IDataStrategy
{
    /// <summary>
    /// Gets the <see cref="TestDataTypes.ArgsCode"/> type enum which determines the strategy of creating test parameters.
    /// </summary>
    ArgsCode ArgsCode { get; }
    bool? WithExpected { get; }
}
