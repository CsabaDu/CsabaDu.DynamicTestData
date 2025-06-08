// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsabaDu.DynamicTestData.SampleCodes.MSTestSamples;

[TestClass]
public sealed class BirthdayTests
{
    private static readonly BirthdayObjectArraySource DataSource = new(ArgsCode.Instance, null);
    private const string DisplayName = nameof(GetDisplayName);

    public static string? GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSourceBase.GetDisplayName(testMethod.Name, args);

    #region ArgsCode.Instance
    private static IEnumerable<object?[]>? BirthDayConstructorInvalidArgs
    => DataSource.GetBirthDayConstructorInvalidArgs();

    [TestMethod]
    [DynamicData(nameof(BirthDayConstructorInvalidArgs), DynamicDataDisplayName = DisplayName)]
    public void Ctor_invalidArgs_throwsArgumentException(TestDataThrows<ArgumentException, string> testData)
    {
        // Arrange
        var expected = testData.Expected;
        var name = testData.Arg1;
        var dateOfBirth =
            DateOnly.FromDateTime(DateTime.Now).AddDays(1);

        // Act
        void attempt() => _ = new BirthDay(name!, dateOfBirth);

        // Assert
        var actual = Assert.Throws<ArgumentException>(attempt);
        Assert.IsInstanceOfType(actual, expected.GetType());
        Assert.AreEqual(expected.ParamName, actual.ParamName);
        Assert.AreEqual(expected.Message, actual.Message);
    }

    private static IEnumerable<object?[]>? BirthDayConstructorValidArgs
    => DataSource.GetBirthDayConstructorValidArgs();

    [TestMethod]
    [DynamicData(nameof(BirthDayConstructorValidArgs), DynamicDataDisplayName = DisplayName)]
    public void Ctor_validArgs_createsInstance(TestData<DateOnly> testData)
    {
        // Arrange
        string name = "valid name";
        var dateOfBirth = testData.Arg1;

        // Act
        var actual = new BirthDay(name!, dateOfBirth);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(name, actual.Name);
        Assert.AreEqual(dateOfBirth, actual.DateOfBirth);
    }

    private static IEnumerable<object?[]>? CompareToArgs
    => DataSource.GetCompareToArgs();

    [TestMethod]
    [DynamicData(nameof(CompareToArgs), DynamicDataDisplayName = DisplayName)]
    public void CompareTo_args_returnsExpected(TestDataReturns<int, DateOnly, BirthDay> testData)
    {
        // Arrange
        var dateOfBirth = testData.Arg1;
        var other = testData.Arg2;
        var sut = new BirthDay("name", dateOfBirth);

        // Act
        var actual = sut.CompareTo(other);

        // Assert
        Assert.AreEqual(testData.Expected, actual);
    }
    #endregion

    #region ArgsCode.Properties
    private static IEnumerable<object?[]>? BirthDayConstructorInvalidArgsProps
    => DataSource.GetBirthDayConstructorInvalidArgs(ArgsCode.Properties);

    [TestMethod]
    [DynamicData(nameof(BirthDayConstructorInvalidArgsProps), DynamicDataDisplayName = DisplayName)]
    public void Ctor_Props_invalidArgs_throwsArgumentException(string ignored,
        ArgumentException expected,
        string name)
    {
        // Arrange
        DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

        // Act
        void attempt() => _ = new BirthDay(name!, dateOfBirth);

        // Assert
        var actual = Assert.Throws<ArgumentException>(attempt);
        Assert.IsInstanceOfType(actual, expected.GetType());
        Assert.AreEqual(expected.ParamName, actual.ParamName);
        Assert.AreEqual(expected.Message, actual.Message);
    }

    private static IEnumerable<object?[]>? BirthDayConstructorValidArgsProps
    => DataSource.GetBirthDayConstructorValidArgs(ArgsCode.Properties);

    [TestMethod]
    [DynamicData(nameof(BirthDayConstructorValidArgsProps), DynamicDataDisplayName = DisplayName)]
    public void Ctor_Props_validArgs_createsInstance(string ignored,
        DateOnly dateOfBirth)
    {
        // Arrange
        string name = "valid name";

        // Act
        var actual = new BirthDay(name!, dateOfBirth);

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(name, actual.Name);
        Assert.AreEqual(dateOfBirth, actual.DateOfBirth);
    }

    private static IEnumerable<object?[]>? CompareToArgsProps
    => DataSource.GetCompareToArgs(ArgsCode.Properties);

    [TestMethod]
    [DynamicData(nameof(CompareToArgsProps), DynamicDataDisplayName = DisplayName)]
    public void CompareTo_Props_args_returnsExpected(string ignored,
        int expected,
        DateOnly dateOfBirth,
        BirthDay other)
    {
        // Arrange
        var sut = new BirthDay("name", dateOfBirth);

        // Act
        var actual = sut.CompareTo(other);

        // Assert
        Assert.AreEqual(expected, actual);
    }
    #endregion
}
