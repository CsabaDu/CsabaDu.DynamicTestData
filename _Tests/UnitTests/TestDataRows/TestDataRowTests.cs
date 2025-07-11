//// SPDX-License-Identifier: MIT
//// Copyright (c) 2025. Csaba Dudas (CsabaDu)

//using CsabaDu.DynamicTestData.TestDataHolders;
//using static CsabaDu.DynamicTestData.Tests.TheoryDataSources.TestDataRowTheoryDataSources;

//namespace CsabaDu.DynamicTestData.Tests.UnitTests.TestDataHolders;

//public sealed class TestDataRowTests
//{
//    #region Constructor tests
//    [Fact]
//    public void TestDataRow_invalidArgsCode_throwsInvalidEnumArgumentException()
//    {
//        // Arrange
//        string expectedParamName = "argsCode";

//        // Act
//        void attempt() => _ = new TestDataRow<TestData<int>>(TestDataArgs1, InvalidArgsCode);

//        // Assert
//        var actual = Assert.Throws<InvalidEnumArgumentException>(attempt);
//        Assert.Equal(expectedParamName, actual.ParamName);
//    }

//    [Fact]
//    public void TestDataRow_nullTestData_throwsArgumentNullException()
//    {
//        // Arrange
//        string expectedParamName = "testData";
//        TestDataReturns<DummyEnum, int> testData = null;

//        // Act
//        void attempt() => _ = new TestDataRow<TestDataReturns<DummyEnum, int>>(testData, InvalidArgsCode);

//        // Assert
//        var actual = Assert.Throws<ArgumentNullException>(attempt);
//        Assert.Equal(expectedParamName, actual.ParamName);
//    }

//    [Theory, MemberData(nameof(ArgsCodeTheoryData), MemberType = typeof(SharedTheoryData))]
//    public void TestDataRow_validArgs_createsInstance(ArgsCode argsCode)
//    {
//        // Arrange & Act
//        var actual = new TestDataRow<TestDataThrows<DummyException, int>>(TestDataThrowsArgs1, argsCode);

//        // Assert
//        Assert.NotNull(actual);
//        Assert.Equal(argsCode, actual.ArgsCode);
//    }

//    [Theory, MemberData(nameof(BooleanTheoryData), MemberType = typeof(SharedTheoryData))]
//    public void TestDataRow_booleanArg_createsInstance(bool withExpected)
//    {
//        // Arrange & Act
//        var actual = new TestDataRow<TestDataThrows<DummyException, int>>(TestDataThrowsArgs1, default, withExpected);

//        // Assert
//        Assert.NotNull(actual);
//    }
//    #endregion

//    #region GetTestParameters tests
//    [Theory, MemberData(nameof(GetParametersTheoryData), MemberType = typeof(TestDataRowTheoryDataSources))]
//    public void GetTestParameters_returnsExpected(TestDataReturns<DummyEnum, int> testData, ArgsCode argsCode, bool withExpected, object[] expected)
//    {
//        TestDataRow<TestDataReturns<DummyEnum, int>> testDataRow = new(testData, argsCode, withExpected);
//        var actual = testDataRow.GetParameters();

//        Assert.Equal(expected, actual);
//    }
//    #endregion
//}
