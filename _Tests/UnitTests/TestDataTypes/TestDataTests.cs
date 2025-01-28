namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private readonly TestData _sut = TestDataTestsDynamicDataSource.TestData;

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.TestCaseArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void TestCase_returnsExpected(string definition, string exitMode, string result, string expected)
    {
        // Arrange
        var testData = new TestDataChild(definition, result, exitMode);

        // Act
        var actual = testData.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ToArgsArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ToArgs_validArg_ArgsCode_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange

        // Act
        var actual = _sut.ToArgs(argsCode);

        // Assert
        Assert.Single(actual);
        Assert.Equal(expected[0], actual[0]);
    }

    [Fact]
    public void ToArgs_InvalidArg_ArgsCode_throws_InvalidEnumArgumentException()
    {
        // Arrange
        ArgsCode argsCode = (ArgsCode)Enum.GetNames<ArgsCode>().Length;
        string paramName = nameof(argsCode);

        // Act
        void attempt() => _sut.ToArgs(argsCode);

        // Assert
        var exception = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(paramName, exception.ParamName);
    }
}