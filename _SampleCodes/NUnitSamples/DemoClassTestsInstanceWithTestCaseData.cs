// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class DemoClassTestsInstanceWithTestCaseData
{
    private readonly DemoClass _sut = new();
    private static readonly TestCaseDataSource DataSource = new(ArgsCode.Instance);

    private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
    => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

    private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
    => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

    [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
    public bool IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act & Assert
        return _sut.IsOlder(testData.Arg1, testData.Arg2);
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
