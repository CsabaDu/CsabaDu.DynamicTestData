using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class DemoClassTests
{
    private readonly DemoClass _sut = new();

    private static DemoClassTestsDataSource_Native DataSource = new(ArgsCode.Properties);

    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), DynamicDataDisplayName = nameof(GetDisplayName))]
    public void IsOlder_validArgs_returnsExpected(string testCase,
                                                  bool expected,
                                                  DateTime thisDate,
                                                  DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), DynamicDataDisplayName = nameof(GetDisplayName))]
    public void IsOlder_invalidArgs_throwsArgumentOutOfRangeException(string testCase,
                                                                      string paramName,
                                                                      string message,
                                                                      Type exceptionType,
                                                                      DateTime thisDate,
                                                                      DateTime otherDate)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

        // Assert
        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(attempt);
        Assert.AreEqual(paramName, exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith(message));
    }
}
