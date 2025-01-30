namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataReturnsTests
{
    private ITestData _sut;

    private static TestDataReturnsChild<TStruct> GetTestDataReturnsChild<TStruct>(string definition, TStruct expected) where TStruct : struct
    => new(definition, expected);

    private static TestDataReturnsChild<DummyEnum> GetTestDataReturnsChild()
    => Params.TestDataReturnsChild;

    #region Abstract TestDataReturns tests
    #region Properties tests
    [Fact]
    public void ExitMode_getsExpected()
    {
        // Arrange
        _sut = GetTestDataReturnsChild();
        string expected = TestData.Returns;

        // Act
        var actual = _sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Expected_getsExpected()
    {
        // Arrange
        _sut = GetTestDataReturnsChild();
        DummyEnum expected = Params.DummyEnumTestValue;

        // Act
        var actual = (_sut as TestDataReturnsChild<DummyEnum>).Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(TestDataReturnsTestsDataSource.ReturnsArgsList), MemberType = typeof(TestDataReturnsTestsDataSource))]
    public void Result_getsExpected<TStruct>(TStruct expectedStruct, string expected) where TStruct : struct
    {
        // Arrange
        _sut = GetTestDataReturnsChild(null, expectedStruct);

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestDataReturns tests
    #region Methods tests
    [Theory, MemberData(nameof(TestDataReturnsTestsDataSource.ToArgsArgsList), MemberType = typeof(TestDataTestsDataSource))]
    public void ToArgs_args_returnsExpected(ArgsCode argsCode, ITestData sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(argsCode);

        // Assert
        SupplementaryAssert.ArraysEqual(expected, actual);
    }
    #endregion
    #endregion
}
