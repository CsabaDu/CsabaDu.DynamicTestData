using CsabaDu.DynamicTestData.Tests.DummyTypes;
using static CsabaDu.DynamicTestData.Tests.DynamicDataSources.TestDataThrowsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataThrowsTests
{
    private ITestDataThrows<DummyException> _sut;
    private static readonly Type DummyExceptionType = typeof(DummyException);

    private static string ExitModeResult
    => GetExitModeResult(TestData.Throws, DummyExceptionType.Name);

    private static TestDataThrowsChild<TException> GetTestDataThrowsChild<TException>(string definition, string paramName, string message)
        where TException : Exception
    => new(definition, paramName, message);

    #region Abstract TestDataThrows tests
    #region Properties tests
    [Fact]
    public void ExitMode_getsExpected()
    {
        // Arrange
        _sut = Params.TestDataThrowsChild;
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
        var sut = Params.TestDataThrowsChild;
        Type expected = typeof(DummyException);

        // Act
        var actual = sut.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Result_getsExpected()
    {
        // Arrange
        _sut = Params.TestDataThrowsChild;
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
        _sut = Params.TestDataThrowsChild;
        string expected = GetTestDataTestCase(ActualDefinition, ExitModeResult);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTheoryData.PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void ParamName_getsExpected(string paramName, string expected)
    {
        // Arrange
        _sut = GetTestDataThrowsChild<DummyException>(null, paramName, null);

        // Act
        var actual = _sut.ParamName;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataTheoryData.PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void Message_getsExpected(string message, string expected)
    {
        // Arrange
        _sut = GetTestDataThrowsChild<DummyException>(null, null, message);

        // Act
        var actual = _sut.Message;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestDataReturns tests
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
