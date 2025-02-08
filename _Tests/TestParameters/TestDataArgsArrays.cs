namespace CsabaDu.DynamicTestData.Tests.TestParameters;

public class TestDataArgsArrays
{
    /// <summary>
    /// Test data arguments for the first test case.
    /// </summary>
    public static readonly object[] TestDataArgs0
        = [TestDataChildInstance.TestCase];

    /// <summary>
    /// Test data arguments for the first test case with expected return values.
    /// </summary>
    public static readonly object[] TestDataReturnsArgs0
        = [TestDataReturnsChildInstance.TestCase, DummyEnumTestValue];

    /// <summary>
    /// Test data arguments for the first test case that is expected to throw an exception.
    /// </summary>
    public static readonly object[] TestDataThrowsArgs0
        = [TestDataThrowsChildInstance.TestCase, DummyExceptionInstance];
}
