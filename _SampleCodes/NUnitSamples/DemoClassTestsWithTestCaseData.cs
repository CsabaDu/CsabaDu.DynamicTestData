﻿//using NUnit.Framework;

//namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

//[TestFixture]
//public sealed class DemoClassTestsWithTestCaseData
//{
//    private readonly DemoClass _sut = new();
//    private static readonly TestCaseDataSource DataSource = new(ArgsCode.Properties);

//    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
//    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

//    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
//    => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

//    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
//    public void IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
//    {
//        // Arrange & Act
//        var actual = _sut.IsOlder(thisDate, otherDate);

//        // Assert
//        Assert.That(actual, Is.EqualTo(expected));
//    }

//    [TestCaseSource(nameof(IsOlderThrowsTestCaseDataToList))]
//    public void IsOlder_invalidArgs_throwsException(ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
//    {
//        // Arrange & Act
//        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

//        // Assert
//        Assert.Multiple(() =>
//        {
//            var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
//            Assert.That(actual?.ParamName, Is.EqualTo(expected.ParamName));
//            Assert.That(actual?.Message, Is.EqualTo(expected.Message));
//        });
//    }
//}
