namespace CsabaDu.DynamicTestData.TestDataTypes.Interfaces;

internal interface ITestDataReturns<TStruct> : ITestData<TStruct> where TStruct : struct
{
    TStruct Expected { get; }
}
