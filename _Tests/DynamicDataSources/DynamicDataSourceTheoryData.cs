namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class DynamicDataSourceTheoryData
{
    public static TheoryData<ArgsCode> GetDisplayNameTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };
}
