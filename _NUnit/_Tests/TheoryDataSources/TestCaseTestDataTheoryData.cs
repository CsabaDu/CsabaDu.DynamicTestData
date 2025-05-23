// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.Tests.TheoryDataSources;

public class TestCaseTestDataTheoryData
{
    public static TheoryData<TestData, ArgsCode, string, object> TestCaseTestDataTheoryDataSource => new()
    {
        { TestDataArgs1, ArgsCode.Properties, null, null },
        { TestDataArgs2, ArgsCode.Properties, TestMethodName, null },
        { TestDataArgs3, ArgsCode.Instance, null, null },
        { TestDataArgs4, ArgsCode.Instance, TestMethodName, null },
        { TestDataReturnsArgs1, ArgsCode.Properties, null, DummyEnumTestValue },
        { TestDataReturnsArgs2, ArgsCode.Properties, TestMethodName, DummyEnumTestValue },
        { TestDataReturnsArgs3, ArgsCode.Instance, null, DummyEnumTestValue },
        { TestDataReturnsArgs4, ArgsCode.Instance, TestMethodName, DummyEnumTestValue },
        { TestDataThrowsArgs1, ArgsCode.Properties, null, null },
        { TestDataThrowsArgs2, ArgsCode.Properties, TestMethodName, null },
        { TestDataThrowsArgs3, ArgsCode.Instance, null, null },
        { TestDataThrowsArgs4, ArgsCode.Instance, TestMethodName, null },
    };
}
