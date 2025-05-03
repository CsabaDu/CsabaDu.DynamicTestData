// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class DemoClassTestsInstance
{
    private readonly DemoClass _sut = new();
    private static readonly NativeTestDataSource DataSource = new(ArgsCode.Instance);
    private const string DisplayName = nameof(GetDisplayName);

    private static IEnumerable<object?[]> IsOlderReturnsArgsList
    => DataSource.IsOlderReturnsArgsToList();

    private static IEnumerable<object?[]> IsOlderThrowsArgsList
    => DataSource.IsOlderThrowsArgsToList();

    public static string GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSource.GetDisplayName(testMethod.Name, args);

    [TestMethod]
    [DynamicData(nameof(IsOlderReturnsArgsList), DynamicDataDisplayName = DisplayName)]
    public void IsOlder_validArgs_returnsExpected(TestDataReturns<bool, DateTime, DateTime> testData)
    {
        // Arrange & Act
        var actual = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        Assert.AreEqual(testData.Expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(IsOlderThrowsArgsList), DynamicDataDisplayName = DisplayName)]
    public void IsOlder_invalidArgs_throwsException(TestDataThrows<ArgumentOutOfRangeException, DateTime, DateTime> testData)
    {
        // Arrange & Act
        void attempt() => _ = _sut.IsOlder(testData.Arg1, testData.Arg2);

        // Assert
        var actual = Assert.ThrowsException<ArgumentOutOfRangeException>(attempt);
        Assert.AreEqual(testData.Expected.ParamName, actual.ParamName);
        Assert.AreEqual(testData.Expected.Message, actual.Message);
    }
}
