// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestCaseTestDataTypes;

public class TestCaseTestData : TestCaseData
{
    public TestCaseTestData(TestData testData, ArgsCode argsCode)
    : base(testData.ToArguments(argsCode))
    => Properties.Set(PropertyNames.Description, testData.TestCase);
}

public class TestCaseTestData<TStruct> : TestCaseTestData
where TStruct : struct
{
    public TestCaseTestData(TestDataReturns<TStruct> testData, ArgsCode argsCode)
    : base(testData, argsCode)
    => ExpectedResult = testData.Expected;
}
