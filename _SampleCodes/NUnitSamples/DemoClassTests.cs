using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class DemoClassTests
{

    private readonly DemoClass _sut = new();
    private static readonly DemoClassTestsNativeDataSource DataSource = new(ArgsCode.Instance);

    public static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    public static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    [TestCaseSource(nameof(IsOlderReturnsArgsList))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.That(actual, Is.EqualTo(testData.Expected));
    }

    [TestCaseSource(nameof(IsOlderThrowsArgsList))]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Multiple(() =>
        {
            var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
            Assert.That(actual?.ParamName, Is.EqualTo(testData.Expected.ParamName));
            Assert.That(actual?.Message, Is.EqualTo(testData.Expected.Message));
        });
    }


    //private readonly DemoClass _sut = new();
    //private static readonly DemoClassTestsNativeDataSource DataSource = new(ArgsCode.Instance);

    //public static IEnumerable<TestCaseData> IsOlderReturnsArgsList
    //=> GetDataList("IsOlder_validArgs_returnsExpected", DataSource.IsOlderReturnsArgsToList());

    //public static IEnumerable<TestCaseData> IsOlderThrowsArgsList
    //=> GetDataList("IsOlder_validArgs_returnsExpected", DataSource.IsOlderThrowsArgsToList());

    //private static IEnumerable<TestCaseData> GetDataList(string testMethodName, IEnumerable<object?[]> argsList)
    //{
    //    Type thisType = typeof(DemoClassTests);
    //    MethodInfo testMethod = thisType.GetMethod(testMethodName)!;

    //    foreach (object?[] args in argsList)
    //    {
    //        string displayName = DynamicDataSource.GetDisplayName(testMethod, args);
    //        TestCaseData data = new(args);
    //        yield return data.SetName(displayName);
    //    }
    //}

    //[Theory, MemberData(nameof(IsOlderReturnsArgsList))]
    //public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    //{
    //    // Arrange & Act
    //    var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

    //    // Assert
    //    Assert.Equal(testData.Expected, actual);
    //}

    //[Theory, MemberData(nameof(IsOlderThrowsArgsList))]
    //public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    //{
    //    // Arrange & Act
    //    void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

    //    // Assert
    //    var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
    //    Assert.Equal(testData.Expected.ParamName, actual.ParamName);
    //    Assert.Equal(testData.Expected.Message, actual.Message);
    //}
}
