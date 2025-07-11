// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources
{
    public class TestDataRowTheoryDataSources
    {

        public static TheoryData<TestDataReturns<DummyEnum, int>, ArgsCode, bool, object[]> GetParametersTheoryData => new()
        {
            { TestDataReturnsArgs1, ArgsCode.Instance, false, [TestDataReturnsArgs1] },
            { TestDataReturnsArgs1, ArgsCode.Instance, true, [TestDataReturnsArgs1] },
            { TestDataReturnsArgs1, ArgsCode.Properties, false, [Arg1] },
            { TestDataReturnsArgs1, ArgsCode.Properties, true, [DummyEnumTestValue, Arg1] },
        };
    }
}
