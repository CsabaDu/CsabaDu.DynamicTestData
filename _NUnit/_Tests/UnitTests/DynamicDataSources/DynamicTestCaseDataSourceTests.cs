using CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;
using static CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources.DynamicTestCaseDataSourceTheoryData;

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.DynamicDataSources;

public sealed class DynamicTestCaseDataSourceTests
{

    private DynamicTestCaseDataSourceChild _sut;

    [Xunit.Theory, MemberData(nameof(TestDataToTestCaseData1ArgsTheoryData), MemberType = typeof(DynamicTestCaseDataSourceTheoryData))]
    public void TestDataToArgs_1args_returnsExpected(ArgsCode argsCode, string testMethodName, bool shouldBeEqual, TestCaseData expected)
    {
        // Arrange
        _sut = new DynamicTestCaseDataSourceChild(argsCode);

        // Act
        var actual = _sut.TestDataToTestCaseData(ActualDefinition, ExpectedString, Arg1, testMethodName);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(shouldBeEqual, actual.TestName == TestDataDisplayName);
    }
}
