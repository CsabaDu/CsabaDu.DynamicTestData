namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataReturnsTests
{
    private ITestData _sut;

    private TestDataReturnsChild<DummyEnum> SutDummyEnum
    => _sut as TestDataReturnsChild<DummyEnum>;

    private static TestDataReturnsChild<TStruct> GetTestDataReturnsChild<TStruct>(string definition, TStruct expected) where TStruct : struct
    => new(definition, expected);

    private static TestDataReturnsChild<DummyEnum> GetTestDataReturnsChild()
    => Params.TestDataReturnsChild;

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
        DummyEnum expected = DummyEnum.TestValue;

        // Act
        var actual = SutDummyEnum.Expected;

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

    #region Methods tests

    #endregion
}
