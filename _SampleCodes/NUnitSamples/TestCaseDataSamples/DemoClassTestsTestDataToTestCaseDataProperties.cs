// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

class DemoClassTestsTestDataToTestCaseDataProperties
{
    public sealed class DemoClassTestsPropertiesWithTestCaseData
    {
        private readonly DemoClass _sut = new();
        private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Properties);

        // ArgsCode Overriden
        private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
        => DataSource.IsOlderReturnsTestCaseDataToList(null, ArgsCode.Instance);

        private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
        => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

        // Signature of the thest method adjusted to comply with the overriden ArgsCode.
        [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
        public bool IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
        {
            // Arrange & Act & Assert
            return _sut.IsOlder(testData.Arg1, testData.Arg2);
        }

        [TestCaseSource(nameof(IsOlderThrowsTestCaseDataToList))]
        public void IsOlder_invalidArgs_throwsException(ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
        {
            // Arrange & Act
            void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

            // Assert
            Assert.Multiple(() =>
            {
                var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
                Assert.That(actual?.ParamName, Is.EqualTo(expected.ParamName));
                Assert.That(actual?.Message, Is.EqualTo(expected.Message));
            });
        }
    }
}