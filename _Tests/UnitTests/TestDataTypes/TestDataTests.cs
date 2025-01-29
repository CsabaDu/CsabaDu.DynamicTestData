namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private TestDataChild _sut;
    private static readonly string ExpectedString = Params.ExpectedString;

    private void SetTestDataChild(string definition, string result, string exitMode) => _sut = new(definition, exitMode, result);

    private void SetTestDataChild() => _sut = Params.TestData;

    #region Abstract TestData tests
    #region Properties tests
    [Theory, MemberData(nameof(TestDataTestsDataSources.TestCaseArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void TestCase_getsExpected(string definition, string exitMode, string result, string expected)
    {
        // Arrange
        SetTestDataChild(definition, result, exitMode);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDataSources.PropertyArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void Definition_getsExpected(string definition, string expected)
    {
        // Arrange
        SetTestDataChild(definition, null, null);

        // Act
        var actual = _sut.Definition;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDataSources.PropertyArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void Result_getsExpected(string result, string expected)
    {
        // Arrange
        SetTestDataChild(null, result, null);

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDataSources.PropertyArgsList), MemberType = typeof(TestDataTestsDataSources))]
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
    [Theory, MemberData(nameof(TestDataTestsDataSources.ToArgsArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void ToArgs_validArg_ArgsCode_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        SetTestDataChild();

        // Act
        var actual = _sut.ToArgs(argsCode);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
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

    [Fact]
    public void ToString_returnsExpected()
    {
        // Arrange
        SetTestDataChild();
        string expected = _sut.TestCase;

        // Act
        var actual = _sut.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestData tests
    #region Properties tests
    [Fact]
    public void ExitMode_remainsVirtual_getsExpected()
    {
        // Arrange
        var sut = new TestData<int>(null, null, 1);
        string expected = string.Empty;

        // Act
        var actual = sut.ExitMode;

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

    [Theory, MemberData(nameof(TestDataTestsDataSources.PropertyArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void Expected_getsExpected(string expectedString, string expected)
    {
        // Arrange
        TestData<string> testData = new(null, expectedString, null);

        // Act
        var actual = testData.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Methods tests
    [Theory, MemberData(nameof(TestDataTestsDataSources.ToArgsArgsCodeInstanceArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void ToArgs_arg_ArgsCodeInstance_returnsExpected(ITestData<string> sut)
    {
        // Arrange
        object[] expected = [sut];

        // Act
        var actual = sut.ToArgs(ArgsCode.Instance);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTestsDataSources.ToArgsArgsCodePropertiesArgsList), MemberType = typeof(TestDataTestsDataSources))]
    public void ToArgs_arg_ArgsCodeProperties_returnsExpected(ITestData<string> sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(ArgsCode.Properties);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
    }
    #endregion
    #endregion
}
