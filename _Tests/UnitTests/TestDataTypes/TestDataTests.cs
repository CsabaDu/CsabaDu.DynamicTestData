namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private TestDataChild _sut;
    private static readonly string ExpectedString = Params.ExpectedString;

    private void SetTestDataChild(string definition, string result, string exitMode) => _sut = new(definition, result, exitMode);

    private void SetTestDataChild() => _sut = Params.TestData;

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
        var testCase = // Assert
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
    #endregion

    #region Methods tests
    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ToArgsArgsCodeInstanceArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ToArgs_arg_ArgsCodeInstance_returnsExpected(ITestData<string> sut)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(ArgsCode.Instance);
        var expected = new object[] { sut };

        // Assert
        Assert.Single(actual);
        Assert.Equal(expected[0], actual[0]);
    }

    [Theory, MemberData(nameof(TestDataTestsDynamicDataSource.ToArgsArgsCodePropertiesArgsList), MemberType = typeof(TestDataTestsDynamicDataSource))]
    public void ToArgs_arg_ArgsCodeProperties_returnsExpected(ITestData<string> sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(ArgsCode.Properties);
        int actualLength = actual.Length;

        // Assert
        Assert.Equal(expected.Length, actualLength);
        Assert.Equal(expected[0], actual[0]);
        Assert.Equal(expected[1], actual[1]);
        if (actualLength > 2)
        {
            Assert.Equal(expected[2], actual[2]);
        }
        if (actualLength > 3)
        {
            Assert.Equal(expected[3], actual[3]);
        }
        if (actualLength > 4)
        {
            Assert.Equal(expected[4], actual[4]);
        }
        if (actualLength > 5)
        {
            Assert.Equal(expected[5], actual[5]);
        }
        if (actualLength > 6)
        {
            Assert.Equal(expected[6], actual[6]);
        }
        if (actualLength > 7)
        {
            Assert.Equal(expected[7], actual[7]);
        }
        if (actualLength > 8)
        {
            Assert.Equal(expected[8], actual[8]);
        }
        if (actualLength > 9)
        {
            Assert.Equal(expected[9], actual[9]);
        }
        if (actualLength > 10)
        {
            Assert.Fail("Args elements count is more than 10.");
        }
    }
    #endregion
    #endregion
}
