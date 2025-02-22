namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

class SharedTheoryData
{
    public static TheoryData<ArgsCode> ArgsCodesTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };
}
