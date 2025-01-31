using CsabaDu.DynamicTestData.Tests.DummyTypes;

namespace CsabaDu.DynamicTestData.Tests.TestDoubles;

public record TestDataReturnsChild<TStruct>(string Definition, TStruct Expected)
    : TestDataReturns<TStruct>(Definition, Expected)
    where TStruct : struct;

public sealed record TestDataReturnsChild(string Definition)
    : TestDataReturnsChild<DummyEnum>(Definition, DummyEnumTestValue);
