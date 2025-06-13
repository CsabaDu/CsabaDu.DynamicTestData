// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework;

namespace CsabaDu.DynamicTestData.SampleCodes.NUnitSamples;

[TestFixture]
public sealed class BirthdayTests_NUnit
{
    private static readonly BirthdayDynamicDataSource DataSource = new(ArgsCode.Instance);
    private const string DisplayName = nameof(GetDisplayName);

    public static string? GetDisplayName(MethodInfo testMethod, object?[] args)
    => DynamicDataSourceBase.GetDisplayName(testMethod.Name, args);

    #region ArgsCode.Instance
    private static IEnumerable<object?[]>? BirthDayConstructorInvalidArgs
    => DataSource.GetBirthDayConstructorInvalidArgs();

    [TestCaseSource(nameof(BirthDayConstructorInvalidArgs))]
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
        Assert.Multiple(() =>
        {
            var actual = Assert.Throws(expected.GetType(), attempt) as ArgumentException;
            Assert.That(expected.ParamName, Is.EqualTo(actual!.ParamName));
            Assert.That(expected.Message, Is.EqualTo(actual.Message));
        });
    }

    private static IEnumerable<object?[]>? BirthDayConstructorValidArgs
    => DataSource.GetBirthDayConstructorValidArgs();

    [TestCaseSource(nameof(BirthDayConstructorValidArgs))]
    public void Ctor_validArgs_createsInstance(TestData<DateOnly> testData)
    {
        // Arrange
        string name = "valid name";
        var dateOfBirth = testData.Arg1;

        // Act
        var actual = new BirthDay(name!, dateOfBirth);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(name, Is.EqualTo(actual.Name));
            Assert.That(dateOfBirth, Is.EqualTo(actual.DateOfBirth));
        });
    }

    private static IEnumerable<object?[]>? CompareToArgs
    => DataSource.GetCompareToArgs();

    [TestCaseSource(nameof(CompareToArgs))]
    public void CompareTo_args_returnsExpected(TestDataReturns<int, DateOnly, BirthDay> testData)
    {
        // Arrange
        var dateOfBirth = testData.Arg1;
        var other = testData.Arg2;
        var sut = new BirthDay("name", dateOfBirth);

        // Act
        var actual = sut.CompareTo(other);

        // Assert
        Assert.That(testData.Expected, Is.EqualTo(actual));
    }
    #endregion

    #region ArgsCode.Properties
    private static IEnumerable<object?[]>? BirthDayConstructorInvalidArgsProps
    => DataSource.GetBirthDayConstructorInvalidArgs(ArgsCode.Properties);

    [TestCaseSource(nameof(BirthDayConstructorInvalidArgsProps))]
    public void Ctor_Props_invalidArgs_throwsArgumentException(string ignored,
        ArgumentException expected,
        string name)
    {
        // Arrange
        DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

        // Act
        void attempt() => _ = new BirthDay(name!, dateOfBirth);

        // Assert
        Assert.Multiple(() =>
        {
            var actual = Assert.Throws(expected.GetType(), attempt) as ArgumentException;
            Assert.That(expected.ParamName, Is.EqualTo(actual!.ParamName));
            Assert.That(expected.Message, Is.EqualTo(actual.Message));
        });
    }

    private static IEnumerable<object?[]>? BirthDayConstructorValidArgsProps
    => DataSource.GetBirthDayConstructorValidArgs(ArgsCode.Properties);

    [TestCaseSource(nameof(BirthDayConstructorValidArgsProps))]
    public void Ctor_Props_validArgs_createsInstance(string ignored,
        DateOnly dateOfBirth)
    {
        // Arrange
        string name = "valid name";

        // Act
        var actual = new BirthDay(name!, dateOfBirth);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(name, Is.EqualTo(actual.Name));
            Assert.That(dateOfBirth, Is.EqualTo(actual.DateOfBirth));
        });
    }

    private static IEnumerable<object?[]>? CompareToArgsProps
    => DataSource.GetCompareToArgs(ArgsCode.Properties);

    [TestCaseSource(nameof(CompareToArgsProps))]
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
        Assert.That(expected, Is.EqualTo(actual));
    }
    #endregion
}
