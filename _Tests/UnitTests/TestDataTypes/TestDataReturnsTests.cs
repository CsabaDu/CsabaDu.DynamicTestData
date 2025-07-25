﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.TestDataReturnsTheoryData;

namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataTypes;

public sealed class TestDataReturnsTests
{
    private ITestData _sut;

    //private static TestDataReturnsChild<TStruct> GetTestDataReturnsChild<TStruct>(string definition, TStruct expected)
    //    where TStruct : struct
    //=> new(definition, expected);

    #region Abstract TestDataReturns tests
    #region Properties tests
    //[Fact]
    //public void ExitMode_getsExpected()
    //{
    //    // Arrange
    //    _sut = TestDataReturnsChildInstance;
    //    string expected = TestData.Returns;

    //    // Act
    //    var actual = _sut.ExitMode;

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}

    [Fact]
    public void Expected_getsExpected()
    {
        // Arrange
        var sut = TestDataReturnsChildInstance;
        DummyEnum expected = DummyEnumTestValue;

        // Act
        var actual = sut.Expected;

        // Assert
        Assert.Equal(expected, actual);
    }

    //[Theory, MemberData(nameof(ReturnsTheoryData), MemberType = typeof(TestDataReturnsTheoryData))]
    //public void Result_getsExpected<TStruct>(TStruct expectedStruct, string expected) where TStruct : struct
    //{
    //    // Arrange
    //    _sut = GetTestDataReturnsChild(null, expectedStruct);

    //    // Act
    //    var actual = _sut.Result;

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}

    //[Fact]
    //public void TestCase_getsExpected()
    //{
    //    // Arrange
    //    _sut = TestDataReturnsChildInstance;
    //    string expectedString = DummyEnumTestValue.ToString();
    //    string exitModeResult = GetExitModeResult(TestData.Returns, expectedString);
    //    string expected = GetTestDataTestCase(ActualDefinition, exitModeResult);

    //    // Act
    //    var actual = _sut.TestCaseName;

    //    // Assert
    //    Assert.Equal(expected, actual);
    //}
    #endregion

    #region GetExpected tests
    [Fact]
    public void GetExpected_returnsExpected()
    {
        // Arrange
        var sut = TestDataReturnsChildInstance;
        DummyEnum expected = DummyEnumTestValue;

        // Act
        var actual = sut.GetExpected();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion
    #endregion

    #region Concrete TestDataReturns tests
    #region Methods tests
    [Theory, MemberData(nameof(PropertiesToArgsTheoryData), MemberType = typeof(TestDataReturnsTheoryData))]
    public void PropertiesToArgs_getsExpected(bool withExpected, object[] expected)
    {
        // Arrange
        TestDataReturns<DummyEnum, int> sut = TestDataReturnsArgs3;

        // Act
        var actual = sut.PropertiesToParams(withExpected);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory, MemberData(nameof(ToArgsTheoryData), MemberType = typeof(TestDataReturnsTheoryData))]
    public void ToArgs_args_returnsExpected(ArgsCode argsCode, ITestDataReturns<DummyEnum> sut, object[] expected)
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
