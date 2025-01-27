namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public sealed record TestDataReturnsChild<TStruct>(string Definition, TStruct Expected)
    : TestDataReturns<TStruct>(Definition, Expected)
    where TStruct : struct;
