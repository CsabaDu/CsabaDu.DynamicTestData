namespace CsabaDu.DynamicTestData.Tests.TestParameters;

public class TestDataArgsArrays
{
    public static readonly object[] TestDataArgs0
        = [Params.TestDataChild.TestCase];

    public static readonly object[] TestDataReturnsArgs0
        = [Params.TestDataReturnsChild.TestCase, DummyEnumTestValue];

    public static readonly object[] TestDataThrowsArgs0
        = [Params.TestDataThrowsChild.TestCase, Parameter, ErrorMessage, typeof(DummyException)];
}
