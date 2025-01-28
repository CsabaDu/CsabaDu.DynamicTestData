namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private readonly TestDataChild _sut = TestDataTestsDynamicDataSource.TestData;

    #region Abstract TestData tests
    #region TestCase tests
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
    #endregion

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.DefinitionArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void DEfinition_returnsExpected(string definition, string expected)
    {
        // Arrange
        var testData = new TestDataChild(definition, null, null);

        // Act
        var actual = testData.Definition;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ResultArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void Result_returnsExpected(string result, string expected)
    {
        // Arrange
        var testData = new TestDataChild(null, result, null);

        // Act
        var actual = testData.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ExitModeArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ExitMode_returnsExpected(string exitMode, string expected)
    {
        // Arrange
        var testData = new TestDataChild(null, null, exitMode);

        // Act
        var actual = testData.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }

    #region ToArgsTests
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
    #endregion
    #endregion

    #region Concrete TestData tests
    [Theory]
    [InlineData("Definition1", "Expected1", "Arg1", new object[] { "Definition1 => Expected1", "Arg1" })]
    [InlineData("Definition2", "Expected2", "Arg2", new object[] { "Definition2 => Expected2", "Arg2" })]
    public void TestData_WithOneArgument_ToArgs_ReturnsExpected(string definition, string expected, string arg1, object[] expectedArgs)
    {
        // Arrange
        var testData = new TestData<string>(definition, expected, arg1);

        // Act
        var actualArgs = testData.ToArgs(ArgsCode.Properties);

        // Assert
        Assert.Equal(expectedArgs, actualArgs);
    }

    [Theory]
    [InlineData("Definition1", "Expected1", "Arg1", "Arg2", new object[] { "Definition1 => Expected1", "Arg1", "Arg2" })]
    [InlineData("Definition2", "Expected2", "Arg3", "Arg4", new object[] { "Definition2 => Expected2", "Arg3", "Arg4" })]
    public void TestData_WithTwoArguments_ToArgs_ReturnsExpected(string definition, string expected, string arg1, string arg2, object[] expectedArgs)
    {
        // Arrange
        var testData = new TestData<string, string>(definition, expected, arg1, arg2);

        // Act
        var actualArgs = testData.ToArgs(ArgsCode.Properties);

        // Assert
        Assert.Equal(expectedArgs, actualArgs);
    }

    [Theory]
    [InlineData("Definition1", "Expected1", "Arg1", "Arg2", "Arg3", new object[] { "Definition1 => Expected1", "Arg1", "Arg2", "Arg3" })]
    [InlineData("Definition2", "Expected2", "Arg4", "Arg5", "Arg6", new object[] { "Definition2 => Expected2", "Arg4", "Arg5", "Arg6" })]
    public void TestData_WithThreeArguments_ToArgs_ReturnsExpected(string definition, string expected, string arg1, string arg2, string arg3, object[] expectedArgs)
    {
        // Arrange
        var testData = new TestData<string, string, string>(definition, expected, arg1, arg2, arg3);

        // Act
        var actualArgs = testData.ToArgs(ArgsCode.Properties);

        // Assert
        Assert.Equal(expectedArgs, actualArgs);
    }
    #endregion
}
