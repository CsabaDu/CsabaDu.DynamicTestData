namespace CsabaDu.DynamicTestData.TestDataHolders;

public record DataStrategy(ArgsCode ArgsCode, bool? WithExpected)
: IDataStrategy
{
    public static IDataStrategy GetDefaultDataStrategy(ITestData testData)
    => new DataStrategy(
        default,
        testData.IsExpected());

    public static IDataStrategy GetDataStrategyOrDefault(
        IDataStrategy dataStrategy,
        ITestData testData)
    => dataStrategy ?? GetDefaultDataStrategy(testData);
}