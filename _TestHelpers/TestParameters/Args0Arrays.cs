namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class Args0Arrays
{
    /// <summary>
    /// Test data arguments for the first test case.
    /// </summary>
    public static readonly object[] TestDataArgs0
        = [TestDataTestCase];

    /// <summary>
    /// Test data arguments for the first test case with expected return values.
    /// </summary>
    public static readonly object[] TestDataReturnsArgs0
        = [TestDataReturnsTestCase, DummyEnumTestValue];

    /// <summary>
    /// Test data arguments for the first test case that is expected to throw an exception.
    /// </summary>
    public static readonly object[] TestDataThrowsArgs0
        = [TestDataThrowsTestCase, DummyExceptionInstance];
}
