// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.xUnit.Attributes;
using CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes;
using CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes.Interfaces;
using Xunit;

namespace CsabaDu.DynamicTestData.SampleCodes.xUnitSamples.TheoryDataSamples;

public sealed class DemoClassTestsTestDataToTheoryDataProperties : IDisposable
{
    private readonly DemoClass _sut = new();
    private static readonly TestDataToTheoryDataSource DataSource = new(ArgsCode.Properties);

    public void Dispose() => DataSource.ResetTheoryData();

    // ArgsCode Overriden
    public static ITheoryTestData/*<TestDataReturns<bool, DateTime, DateTime>>*/? IsOlderReturnsArgsTheoryData
    => DataSource.IsOlderReturns(ArgsCode.Instance)/* as TheoryData<TestDataReturns<bool, DateTime, DateTime>>*/;

    public static ITheoryTestData/*<ArgumentOutOfRangeException, DateTime, DateTime>*/? IsOlderThrowsArgsTheoryData
    => DataSource.IsOlderThrows()/* as TheoryData<ArgumentOutOfRangeException, DateTime, DateTime>*/;

    // Signature of the thest method adjusted to comply with the overriden ArgsCode.
    [Theory, MemberTestData(nameof(IsOlderReturnsArgsTheoryData))]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.Equal(testData.Expected, actual);
    }

    [Theory, MemberTestData(nameof(IsOlderThrowsArgsTheoryData))]
    public void IsOlder_invalidArgs_throwsException(ArgumentOutOfRangeException expected, DateTime thisDate, DateTime otherDate)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(thisDate, otherDate);

        // Assert
        var actual = Assert.Throws<ArgumentOutOfRangeException>(attempt);
        Assert.Equal(expected.ParamName, actual.ParamName);
        Assert.Equal(expected.Message, actual.Message);
    }
}
