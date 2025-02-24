namespace CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;

public sealed class ExtensionsTheoryData
{
    public static TheoryData<TestData, ArgsCode, TestCaseData> ToTestCaseDataTheoryData => new()
    {
        { TestDataArgs1, ArgsCode.Instance, new(TestDataArgs1) },
        { TestDataArgs2, ArgsCode.Instance, new(TestDataArgs2) },
        { TestDataArgs3, ArgsCode.Instance, new(TestDataArgs3) },
        { TestDataArgs4, ArgsCode.Instance, new(TestDataArgs4) },
        { TestDataArgs5, ArgsCode.Instance, new(TestDataArgs5) },
        { TestDataArgs6, ArgsCode.Instance, new(TestDataArgs6) },
        { TestDataArgs7, ArgsCode.Instance, new(TestDataArgs7) },
        { TestDataArgs8, ArgsCode.Instance, new(TestDataArgs8) },
        { TestDataArgs9, ArgsCode.Instance, new(TestDataArgs9) },

        { TestDataReturnsArgs1, ArgsCode.Instance, new(TestDataReturnsArgs1) },
        { TestDataReturnsArgs2, ArgsCode.Instance, new(TestDataReturnsArgs2) },
        { TestDataReturnsArgs3, ArgsCode.Instance, new(TestDataReturnsArgs3) },
        { TestDataReturnsArgs4, ArgsCode.Instance, new(TestDataReturnsArgs4) },
        { TestDataReturnsArgs5, ArgsCode.Instance, new(TestDataReturnsArgs5) },
        { TestDataReturnsArgs6, ArgsCode.Instance, new(TestDataReturnsArgs6) },
        { TestDataReturnsArgs7, ArgsCode.Instance, new(TestDataReturnsArgs7) },
        { TestDataReturnsArgs8, ArgsCode.Instance, new(TestDataReturnsArgs8) },
        { TestDataReturnsArgs9, ArgsCode.Instance, new(TestDataReturnsArgs9) },

        { TestDataThrowsArgs1, ArgsCode.Instance, new(TestDataThrowsArgs1) },
        { TestDataThrowsArgs2, ArgsCode.Instance, new(TestDataThrowsArgs2) },
        { TestDataThrowsArgs3, ArgsCode.Instance, new(TestDataThrowsArgs3) },
        { TestDataThrowsArgs4, ArgsCode.Instance, new(TestDataThrowsArgs4) },
        { TestDataThrowsArgs5, ArgsCode.Instance, new(TestDataThrowsArgs5) },
        { TestDataThrowsArgs6, ArgsCode.Instance, new(TestDataThrowsArgs6) },
        { TestDataThrowsArgs7, ArgsCode.Instance, new(TestDataThrowsArgs7) },
        { TestDataThrowsArgs8, ArgsCode.Instance, new(TestDataThrowsArgs8) },
        { TestDataThrowsArgs9, ArgsCode.Instance, new(TestDataThrowsArgs9) },

        { TestDataArgs1, ArgsCode.Properties, new(Args1) },
        { TestDataArgs2, ArgsCode.Properties, new(Args2) },
        { TestDataArgs3, ArgsCode.Properties, new(Args3) },
        { TestDataArgs4, ArgsCode.Properties, new(Args4) },
        { TestDataArgs5, ArgsCode.Properties, new(Args5) },
        { TestDataArgs6, ArgsCode.Properties, new(Args6) },
        { TestDataArgs7, ArgsCode.Properties, new(Args7) },
        { TestDataArgs8, ArgsCode.Properties, new(Args8) },
        { TestDataArgs9, ArgsCode.Properties, new(Args9) },

        { TestDataReturnsArgs1, ArgsCode.Properties, new([DummyEnumTestValue, .. Args1]) },
        { TestDataReturnsArgs2, ArgsCode.Properties, new([DummyEnumTestValue, .. Args2]) },
        { TestDataReturnsArgs3, ArgsCode.Properties, new([DummyEnumTestValue, .. Args3]) },
        { TestDataReturnsArgs4, ArgsCode.Properties, new([DummyEnumTestValue, .. Args4]) },
        { TestDataReturnsArgs5, ArgsCode.Properties, new([DummyEnumTestValue, .. Args5]) },
        { TestDataReturnsArgs6, ArgsCode.Properties, new([DummyEnumTestValue, .. Args6]) },
        { TestDataReturnsArgs7, ArgsCode.Properties, new([DummyEnumTestValue, .. Args7]) },
        { TestDataReturnsArgs8, ArgsCode.Properties, new([DummyEnumTestValue, .. Args8]) },
        { TestDataReturnsArgs9, ArgsCode.Properties, new([DummyEnumTestValue, .. Args9]) },

        { TestDataThrowsArgs1, ArgsCode.Properties, new([DummyExceptionInstance, .. Args1]) },
        { TestDataThrowsArgs2, ArgsCode.Properties, new([DummyExceptionInstance, .. Args2]) },
        { TestDataThrowsArgs3, ArgsCode.Properties, new([DummyExceptionInstance, .. Args3]) },
        { TestDataThrowsArgs4, ArgsCode.Properties, new([DummyExceptionInstance, .. Args4]) },
        { TestDataThrowsArgs5, ArgsCode.Properties, new([DummyExceptionInstance, .. Args5]) },
        { TestDataThrowsArgs6, ArgsCode.Properties, new([DummyExceptionInstance, .. Args6]) },
        { TestDataThrowsArgs7, ArgsCode.Properties, new([DummyExceptionInstance, .. Args7]) },
        { TestDataThrowsArgs8, ArgsCode.Properties, new([DummyExceptionInstance, .. Args8]) },
        { TestDataThrowsArgs9, ArgsCode.Properties, new([DummyExceptionInstance, .. Args9]) },
    };

    public static TheoryData<string, bool> ToTestCaseDataSetNameTheoryData => new()
    {
        { null, false },
        { string.Empty, false },
        { TestMethodName, true },
    };
}
