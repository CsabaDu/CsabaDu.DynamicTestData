namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private TestDataChild _sut;
    private static readonly string ExpectedString = TestDataTestsDynamicDataSource.ExpectedString;

    private void SetTestDataChild(string definition, string result, string exitMode) => _sut = new(definition, result, exitMode);

    private void SetTestDataChild() => _sut = TestDataTestsDynamicDataSource.TestData;

    #region Abstract TestData tests
    #region Properties tests
    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.TestCaseArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void TestCase_getsExpected(string definition, string exitMode, string result, string expected)
    {
        // Arrange
        SetTestDataChild(definition, result, exitMode);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.PropertyArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void Definition_getsExpected(string definition, string expected)
    {
        // Arrange
        SetTestDataChild(definition, null, null);

        // Act
        var actual = _sut.Definition;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.PropertyArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void Result_getsExpected(string result, string expected)
    {
        // Arrange
        SetTestDataChild(null, result, null);

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.PropertyArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ExitMode_getsExpected(string exitMode, string expected)
    {
        // Arrange
        SetTestDataChild(null, null, exitMode);

        // Act
        var actual = _sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Methods tests
    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ToArgsArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ToArgs_validArg_ArgsCode_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        SetTestDataChild();

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
        SetTestDataChild();
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
    #region Properties tests
    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.PropertyArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void Expected_getsExpected(string expectedString, string expected)
    {
        // Arrange
        TestData<string> testData = new(null, expectedString, null);

        // Act
        var actual = testData.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Result_override_getsExpected()
    {
        // Arrange
        string expected = ExpectedString;
        TestData<string> testData = new (null, expected, null);

        // Act
        var actual = testData.Result;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Methods tests
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
    #endregion
}
