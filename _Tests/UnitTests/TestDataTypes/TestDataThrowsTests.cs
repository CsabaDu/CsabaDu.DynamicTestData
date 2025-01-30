using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.TestDataThrowsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataThrowsTests
{
    private ITestData _sut;

    private static TestDataThrowsChild<TException> GetTestDataThrowsChild<TException>(string definition, string paramName, string message)
        where TException : Exception
    => new(definition, paramName, message);

    private static TestDataThrowsChild<DummyException> GetTestDataThrowsChild()
    => Params.TestDataThrowsChild;
}
