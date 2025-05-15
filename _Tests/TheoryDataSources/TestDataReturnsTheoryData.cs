// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

public class TestDataReturnsTheoryData
{
    public static TheoryData<ValueType, string> ReturnsTheoryData => new()
    {
        { new DummyStruct(), ExpectedPropertyName },
        { DummyEnumTestValue, Enum.GetName(DummyEnumTestValue) },
    };

    public static TheoryData<bool, object[]> PropertiesToArgsTheoryData => new()
    {
        { true, [DummyEnumTestValue, ..Args3] },
        { false, Args3 },
    };

    public static TheoryData<ArgsCode, ITestDataReturns<DummyEnum>, object[]> ToArgsTheoryData => new()
    {
        #region ArgsCode.Properties
        { ArgsCode.Properties, TestDataReturnsArgs1, [.. TestDataReturnsArgs0, .. Args1] },
        { ArgsCode.Properties, TestDataReturnsArgs2, [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Properties, TestDataReturnsArgs3, [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Properties, TestDataReturnsArgs4, [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Properties, TestDataReturnsArgs5, [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Properties, TestDataReturnsArgs6, [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Properties, TestDataReturnsArgs7, [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Properties, TestDataReturnsArgs8, [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Properties, TestDataReturnsArgs9, [.. TestDataReturnsArgs0, .. Args9] },
        #endregion

        #region ArgsCode.Instance
        { ArgsCode.Instance, TestDataReturnsArgs1, [TestDataReturnsArgs1] },
        { ArgsCode.Instance, TestDataReturnsArgs2, [TestDataReturnsArgs2] },
        { ArgsCode.Instance, TestDataReturnsArgs3, [TestDataReturnsArgs3] },
        { ArgsCode.Instance, TestDataReturnsArgs4, [TestDataReturnsArgs4] },
        { ArgsCode.Instance, TestDataReturnsArgs5, [TestDataReturnsArgs5] },
        { ArgsCode.Instance, TestDataReturnsArgs6, [TestDataReturnsArgs6] },
        { ArgsCode.Instance, TestDataReturnsArgs7, [TestDataReturnsArgs7] },
        { ArgsCode.Instance, TestDataReturnsArgs8, [TestDataReturnsArgs8] },
        { ArgsCode.Instance, TestDataReturnsArgs9, [TestDataReturnsArgs9] },
        #endregion
    };
}
