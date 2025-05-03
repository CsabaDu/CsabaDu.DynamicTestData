// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Instance);

    public void Dispose() => DataSource.ResetTheoryData();
    
    // ArgsCode Overriden
    public static TheoryData<bool, DateTime, DateTime>? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturnsToTheoryData(ArgsCode.Properties) as TheoryData<bool, DateTime, DateTime>;

    public static TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrowsToTheoryData() as TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>;

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [Theory, MemberData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(IsOlderThrowsArgsTheoryData))]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(testData.Expected.ParamName, actual.ParamName);
        Assert.Equal(testData.Expected.Message, actual.Message);
    }
}
