// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.xUnit.Attributes;
using CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataInstance : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Instance);

    public void Dispose() => DataSource.ResetTheoryData();
    
    // ArgsCode Overriden
    public static ITheoryTestData/*<bool, DateTime, DateTime>*/? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturns(ArgsCode.Properties)/* as TheoryData<bool, DateTime, DateTime>*/;

    public static ITheoryTestData/*<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>*/? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrows()/* as TheoryData<TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime>>*/;

    [Theory, MemberTestData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(bool expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(thisDate, otherDate);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberTestData(nameof(IsOlderThrowsArgsTheoryData))]
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
