/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples.TestCaseDataSamples;

class DemoClassTestsTestDataToTestCaseDataProperties
{
    public sealed class DemoClassTestsPropertiesWithTestCaseData
    {
        private readonly DemoClass _sut = new();
        private static readonly TestDataToTestCaseDataSource DataSource = new(ArgsCode.Properties);

        // ArgsCode Overrided
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