namespace CsabaDu.DynamicTestData.xUnit.Tests.TheoryDataSources;

public class DynamicTheoryDataSourceTheoryData
{
    private TheoryData TheoryData { get; set; }

    public static TheoryData<ArgsCode> ArgsCodesTheoryData => new()
    {
        { ArgsCode.Instance },
        { ArgsCode.Properties },
    };

    public static TheoryData<TheoryData<int>, int> AddTestDataToTheoryData1ArgsPropertiesTheoryData => new()
    {
        { new TheoryData<int>(Arg1), 1 },
        { new TheoryData<int>(Arg1){ { Arg1 } }, 2 },
    };

    public static TheoryData<TheoryData<TestData<int>>, int> AddTestDataToTheoryData1ArgsInstanceTheoryData => new()
    {
        { new TheoryData<TestData<int>>(new TestData<int>(Definition, ExpectedString, Arg1)), 1 },
        { new TheoryData<TestData < int >>(new TestData<int>(Definition, ExpectedString, Arg1)){ { new TestData<int>(Definition, ExpectedString, Arg1) } }, 2 },
    };
}
