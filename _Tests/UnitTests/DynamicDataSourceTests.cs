namespace CsabaDu.DynamicTestData.Tests.UnitTests;

public sealed class DynamicDataSourceTests
{
    private DynamicDataSourceChild _sut;

    [Fact]
    public void TestDataToArgs_Properties_1Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, Arg1];

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_2Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args2];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_3Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args3];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_4Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args4];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_5Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args5];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_6Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args6];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_7Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args7];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_8Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, ..Args8];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Properties_9Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Properties);
        object[] expected = [TestDataTestCase, .. Args9];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_1Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs1];

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_2Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs2];

        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_3Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs3];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_4Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs4];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_5Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs5];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_6Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs6];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_7Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs7];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_8Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs8];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestDataToArgs_Instance_9Args_returnsExpected()
    {
        // Arrange
        _sut = new DynamicDataSourceChild(ArgsCode.Instance);
        object[] expected = [TestDataArgs9];
        // Act
        var actual = _sut.TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
        // Assert
        Assert.Equal(expected, actual);
    }
}
