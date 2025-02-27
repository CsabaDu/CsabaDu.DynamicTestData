using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

class DemoClassTestsTestDataToTestCaseDataProperties
{
    public sealed class DemoClassTestsPropertiesWithTestCaseData
    {
        private readonly DemoClass _sut = new();
        private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Properties);

        private static IEnumerable<TestCaseData> IsOlderReturnsTestCaseDataToList()
        => DataSource.IsOlderReturnsTestCaseDataToList(nameof(IsOlder_validArgs_returnsExpected));

        private static IEnumerable<TestCaseData> IsOlderThrowsTestCaseDataToList()
        => DataSource.IsOlderThrowsTestCaseDataToList(nameof(IsOlder_invalidArgs_throwsException));

        [TestCaseSource(nameof(IsOlderReturnsTestCaseDataToList))]
        public bool IsOlder_validArgs_returnsExpected(DateTime thisDate, DateTime otherDate)
        {
            // Arrange & Act & Assert
            return _sut.IsOlder(thisDate, otherDate);
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