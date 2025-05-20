using CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;

public interface ITheoryTestData
{
    //ITheoryTestData GetTheoryTestData();
}

public interface ITheoryTestData<TTestData>
: ITheoryTestData
where TTestData : ITestData
{
    void AddTestData(TTestData testData);

    ITheoryTestData GetTheoryTestData(TTestData testData);
}
