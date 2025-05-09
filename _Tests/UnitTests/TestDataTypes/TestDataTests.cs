﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.TestDataTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataTests
{
    private TestDataChild _sut;

    private void SetTestDataChild(string definition, string result, string exitMode) => _sut = new(definition, exitMode, result);

    private void SetTestDataChild() => _sut = TestDataChildInstance;

    #region Abstract TestData tests
    #region Properties tests
    [Theory, MemberData(nameof(TestCaseTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void TestCase_getsExpected(string definition, string exitMode, string result, string expected)
    {
        // Arrange
        SetTestDataChild(definition, result, exitMode);

        // Act
        var actual = _sut.TestCase;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void Definition_getsExpected(string definition, string expected)
    {
        // Arrange
        SetTestDataChild(definition, null, null);

        // Act
        var actual = _sut.Definition;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void Result_getsExpected(string result, string expected)
    {
        // Arrange
        SetTestDataChild(null, result, null);

        // Act
        var actual = _sut.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof( PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void ExitMode_getsExpected(string exitMode, string expected)
    {
        // Arrange
        SetTestDataChild(null, null, exitMode);

        // Act
        var actual = _sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Methods tests
    [Theory, MemberData(nameof(VirtualToArgsTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void ToArgs_validArg_ArgsCode_returnsExpected(ArgsCode argsCode, object[] expected)
    {
        // Arrange
        SetTestDataChild();

        // Act
        var actual = _sut.ToArgs(argsCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToArgs_InvalidArg_ArgsCode_throws_InvalidEnumArgumentException()
    {
        // Arrange
        SetTestDataChild();
        int invalidValue = Enum.GetNames<ArgsCode>().Length;
        ArgsCode argsCode = (ArgsCode)invalidValue;
        string paramName = nameof(argsCode);

        // Act
        void attempt() => _sut.ToArgs(argsCode);

        // Assert
        var exception = Assert.Throws<InvalidEnumArgumentException>(attempt);
        Assert.Equal(paramName, exception.ParamName);
    }

    [Fact]
    public void ToString_returnsExpected()
    {
        // Arrange
        SetTestDataChild();
        string expected = _sut.TestCase;

        // Act
        var actual = _sut.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestData tests
    #region Properties tests
    [Fact]
    public void ExitMode_null_getsExpected()
    {
        // Arrange
        var sut = new TestData<int>(null, null, 1);
        string expected = null;

        // Act
        var actual = sut.ExitMode;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(ResultOverrideTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void Result_override_getsExpected(string expectedArg, string expected)
    {
        // Arrange
        TestData<string> testData = new (null, expectedArg, null);

        // Act
        var actual = testData.Result;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(PropertyTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void Expected_getsExpected(string expectedString, string expected)
    {
        // Arrange
        TestData<string> testData = new(null, expectedString, null);

        // Act
        var actual = testData.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Methods tests
    [Theory, MemberData(nameof(ToArgsTheoryData), MemberType = typeof(TestDataTheoryData))]
    public void ToArgs_args_returnsExpected(ArgsCode argsCode, ITestData<string> sut, object[] expected)
    {
        // Arrange
        // Act
        var actual = sut.ToArgs(argsCode);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion
}
