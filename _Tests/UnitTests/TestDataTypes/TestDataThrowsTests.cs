using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.TestDataThrowsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataThrowsTests
{
    private TestDataThrowsChild<DummyException> _sut;
    private static readonly Type DummyExceptionType = typeof(DummyException);

    private static string ExitModeResult
    => GetExitModeResult(TestData.Throws, DummyExceptionType.Name);

    #region Abstract TestDataThrows tests
    #region Properties tests
    [Fact]
    public void ExitMode_getsExpected()
    {
        // Arrange
        _sut = TestDataThrowsChildInstance;
        string expected = TestData.Throws;

        // Act
        var actual = _sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Expected_getsExpected()
    {
        // Arrange
        var sut = TestDataThrowsChildInstance;
        DummyException expected = DummyExceptionInstance;

        // Act
        var actual = sut.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Result_getsExpected()
    {
        // Arrange
        _sut = TestDataThrowsChildInstance;
        string expected = DummyExceptionType.Name;

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestCase_getsExpected()
    {
        // Arrange
        _sut = TestDataThrowsChildInstance;
        string expected = GetTestDataTestCase(ActualDefinition, ExitModeResult);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestDataThrows tests
    #region Methods tests
    [Theory, MemberData(nameof(ToArgsTheoryData), MemberType = typeof(TestDataThrowsTheoryData))]
    public void ToArgs_args_returnsExpected(ArgsCode argsCode, ITestDataThrows<DummyException> sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(argsCode);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion
}
