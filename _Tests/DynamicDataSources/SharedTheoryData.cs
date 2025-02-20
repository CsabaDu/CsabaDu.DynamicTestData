namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

class SharedTheoryData
{
    public static TheoryData<ArgsCode> ArgsCodesTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };
}
