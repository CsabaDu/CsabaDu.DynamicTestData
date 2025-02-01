namespace CsabaDu.DynamicTestData.Tests.TestParameters;

public class TestDataArgsArrays
{
    public static readonly object[] TestDataArgs0
        = [TestDataChildInstance.TestCase];

    public static readonly object[] TestDataReturnsArgs0
        = [TestDataReturnsChildInstance.TestCase, DummyEnumTestValue];

    public static readonly object[] TestDataThrowsArgs0
        = [TestDataThrowsChildInstance.TestCase, Parameter, ErrorMessage, typeof(DummyException)];
}
