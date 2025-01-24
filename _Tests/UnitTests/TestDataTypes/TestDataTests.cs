//namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

//public sealed class TestDataTests
//{
//    [Fact]
//    public void TestData_ExitMode_ShouldReturnCorrectExitMode()
//    {
//        // Arrange
//        var testData = new TestDataChild<string>("Definition", "Result");

//        // Act
//        var exitMode = testData.GetType().GetProperty("ExitMode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(testData);

//        // Assert
//        Assert.Equal(string.Empty, exitMode);
//    }

//    [Fact]
//    public void TestData_TestCase_ShouldReturnCorrectTestCase()
//    {
//        // Arrange
//        var testData = new TestDataChild<string>("Definition", "Result");

//        // Act
//        var testCase = testData.TestCase;

//        // Assert
//        Assert.Equal("Definition => Child Result", testCase);
//    }

//    [Fact]
//    public void TestData_ToArgs_ShouldReturnCorrectArgs()
//    {
//        // Arrange
//        var testData = new TestDataChild<string>("Definition", "Result");

//        // Act & Assert
//        Assert.Equal(new object?[] { testData }, testData.ToArgs(ArgsCode.Instance));
//        Assert.Equal(new object?[] { "Definition => Result" }, testData.ToArgs(ArgsCode.Properties));
//    }

//    [Fact]
//    public void TestData_ToArgs_ShouldThrowInvalidEnumArgumentException()
//    {
//        // Arrange
//        var testData = new TestDataChild<string>("Definition", "Result");

//        // Act & Assert
//        Assert.Throws<InvalidEnumArgumentException>(() => testData.ToArgs((ArgsCode)999));
//    }

//    [Fact]
//    public void TestData_ToString_ShouldReturnCorrectString()
//    {
//        // Arrange
//        var testData = new TestDataChild<string>("Definition", "Result");

//        // Act
//        var result = testData.ToString();

//        // Assert
//        Assert.Equal("Definition => Result", result);
//    }

//    [Fact]
//    public void TestData_WithOneArgument_ToArgs_ShouldReturnCorrectArgs()
//    {
//        // Arrange
//        var testData = new TestData<string, int>("Definition", "Result", 1);

//        // Act & Assert
//        Assert.Equal(new object?[] { testData, 1 }, testData.ToArgs(ArgsCode.Instance));
//        Assert.Equal(new object?[] { "Definition => Result", 1 }, testData.ToArgs(ArgsCode.Properties));
//    }

//    [Fact]
//    public void TestData_WithTwoArguments_ToArgs_ShouldReturnCorrectArgs()
//    {
//        // Arrange
//        var testData = new TestData<string, int, string>("Definition", "Result", 1, "Arg2");

//        // Act & Assert
//        Assert.Equal(new object?[] { testData, 1, "Arg2" }, testData.ToArgs(ArgsCode.Instance));
//        Assert.Equal(new object?[] { "Definition => Result", 1, "Arg2" }, testData.ToArgs(ArgsCode.Properties));
//    }

//    // Additional tests for TestData with more arguments can be added similarly
//}
