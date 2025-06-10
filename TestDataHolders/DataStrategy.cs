namespace CsabaDu.DynamicTestData.TestDataHolders;

public record struct DataStrategy(ArgsCode ArgsCode, bool? WithExpected)
: IDataStrategy;