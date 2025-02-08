using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples;

public sealed class DemoClassTests
{
    private readonly DemoClass _sut = new();

    private static DemoClassTestsNativeDataSource DataSource = new(ArgsCode.Instance);

    public static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    [Theory, MemberData(nameof(IsOlderReturnsArgsList))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsArgumentOutOfRangeException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(testData.Expected.ParamName, actual.ParamName);
        Assert.Equal(testData.Expected.Message, actual.Message);
    }
}
