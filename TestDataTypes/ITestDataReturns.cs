namespace CsabaDu.DynamicTestData.TestDataTypes;

internal interface ITestDataReturns<TStruct> : ITestData<TStruct> where TStruct : struct
{
    TStruct Expected { get; }
}
