using CsabaDu.DynamicTestData.NUnit.Statics;
using CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;
using static CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources.ExtensionsTheoryData;

namespace CsabaDu.DynamicTestData.NUnit.Tests.UnitTests.Statics;

public sealed class ExtensionsTests
{
    private TestData _sut;

    #region ToTestCaseData Tests
    [Fact]
    public void ToTestCaseData_invalidArg_ArgsCode_throwsInvalidEnumArgumentException()
    {
        // Arrange
        _sut = TestDataChildInstance;
        string expectedParamName = "argsCode";
        // Act
        void attempt() => _ = _sut.ToTestCaseData(InvalidArgsCode);

        // Assert
        var actual = Xunit.Assert.Throws<InvalidEnumArgumentException>(attempt);
        Xunit.Assert.Equal(expectedParamName, actual.ParamName);
    }

    [Xunit.Theory, MemberData(nameof(ToTestCaseDataTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void ToTestCaseData_validArg_ArgsCode_returnsExpected(TestData sut, ArgsCode argsCode, TestCaseData expected)
    {
        // Arrange
        static object getDescription(TestCaseData testCaseData) => testCaseData.Properties.Get("Description");

        // Act
        var actual = sut.ToTestCaseData(argsCode);

        // Assert
        Xunit.Assert.Equal(expected.Arguments, actual.Arguments);
        Xunit.Assert.Equal(getDescription(expected), getDescription(actual));
    }

    [Xunit.Theory, MemberData(nameof(ToTestCaseDataSetNameTheoryData), MemberType = typeof(ExtensionsTheoryData))]
    public void ToTestCaseData_arg_testMethodName_returnsExpected(string testMethodName, bool expected)
    {
        // Arrange
        _sut = TestDataChildInstance;
        string displayName = DynamicDataSource.GetDisplayName(testMethodName, _sut.TestCase);

        // Act
        TestCaseData testCaseData = _sut.ToTestCaseData(default, testMethodName);
        var actual = testCaseData.TestName == displayName;

        // Assert
        Xunit.Assert.Equal(expected, actual);
    }
    #endregion

    #region ToTestCaseData<TStruct> Tests
    [Fact]
    public void ToTestCaseData_generic_TStruct_returnsExpected()
    {
        // Arrange
        TestDataReturns<DummyEnum> sut = TestDataReturnsChildInstance;

        // Act
        var actual = sut.ToTestCaseData(default);

        // Assert
        Xunit.Assert.Equal(sut.Expected, actual.ExpectedResult);
    }
    #endregion
}
