// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

[TestFixture]
public sealed class DemoClassTestsTestDataToTestCaseDataInstance
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Instance);

    // ArgsCode Overriden
    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected), ArgsCode.Properties);

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList();

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(thisDate, otherDate);
    }

    [TestCaseSource(nameof(IsOlderThrowsTestCaseDataToList))]
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
}
