using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class DemoClassTestsProperties
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Properties);
    private const string DisplayName = nameof(GetDisplayName);
    private const TestDataSourceUnfoldingStrategy Fold = TestDataSourceUnfoldingStrategy.Fold;
    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod.Name, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_validArgs_returnsExpected(string testCase, bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), UnfoldingStrategy = Fold, DynamicDataDisplayName = DisplayName)]
    public void IsOlder_invalidArgs_throwsException(string testCase, ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

        // Assert
        var actual = Assert.ThrowsException<ArgumentOutOfRangeException>(attempt);
        Assert.AreEqual(expected.ParamName, actual.ParamName);
        Assert.AreEqual(expected.Message, actual.Message);
    }
}
