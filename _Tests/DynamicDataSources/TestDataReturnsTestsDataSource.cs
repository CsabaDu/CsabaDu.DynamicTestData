namespace CsabaDu.DynamicTestData.Tests.DynamicDataSources;

public class TestDataReturnsTestsDataSource
{
    public static TheoryData<ValueType, string> ReturnsArgsList => new()
    {
        { new DummyStruct(), string.Empty },
        { DummyEnum.TestValue, Enum.GetName(DummyEnum.TestValue) },
    };
}
