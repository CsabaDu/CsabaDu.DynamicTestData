namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataReturnsTests<TStruct> where TStruct : struct
{
    private TestDataReturnsChild<TStruct> _sut;

    private void SetTestDataReturnsChild(string definition, TStruct expected) => _sut = new(definition, expected);
    private void SetTestDataReturnsChild<DummyEnum>() => _sut = Params.TestDataReturnsChild as TestDataReturnsChild<TStruct>;

}
