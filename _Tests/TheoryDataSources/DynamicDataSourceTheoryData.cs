// SPDX - License - Identifier: MIT
// Copyright(c) 2025.Csaba Dudas(CsabaDu)

namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

public class DynamicDataSourceTheoryData
{
    public static TheoryData<string, object[]> GetTestDisplayNameNullOrEmptyArgsTheoryData => new()
    {
        { null, null },
        { null, [ActualResult] },
        { string.Empty, [ActualResult] },
        { TestMethodName, [] },
        { TestMethodName, [null] },
        { TestMethodName, [new DummyStruct()] }, // ToString() == null;
        { TestMethodName, [string.Empty] },
    };
    //public static TheoryData<ArgsCode, ArgsCode?, Func<object[]>, object[]> OtionalToParamsTheoryData => new()
    //{
    //    #region TestDataToParams
    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataArgs5] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5),  [TestDataArgs5] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataArgs5] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataToParams(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
    //    #endregion

    //    #region TestDataReturnsToParams
    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataReturnsToParams(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
    //    #endregion

    //    #region TestDataThrowsToParams
    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },

    //    { ArgsCode.Instance, null, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
    //    { ArgsCode.Properties, null, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
    //    { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
    //    { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicToParamsChild(ArgsCode.Properties).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
    //    { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicToParamsChild(ArgsCode.Instance).TestDataThrowsToParams(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
    //    #endregion
    //};

    public static TheoryData<ArgsCode, ArgsCode?, ArgsCode> ArgsCodesTheoryData => new()
    {
        { ArgsCode.Instance, null, ArgsCode.Instance },
        { ArgsCode.Properties, null, ArgsCode.Properties },
        { ArgsCode.Instance, ArgsCode.Properties, ArgsCode.Properties },
        { ArgsCode.Properties, ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Instance, ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Properties, ArgsCode.Properties, ArgsCode.Properties },
    };

    #region TestDataToParams data sources
    public static TheoryData<ArgsCode, object[]> TestDataToParams1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs1] },
        { ArgsCode.Properties, [.. TestDataArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs2] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs3] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs4] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs5] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs6] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs7] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs8] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToParams9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs9] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args9] },
    };
    #endregion

    #region TestDataReturnsToParams data sources
    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs1] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs2] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs3] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs4] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs5] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs6] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs7] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs8] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToParams9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs9] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args9] },
    };
    #endregion

    #region TestDataThrowsToParams data sources
    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs1] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs2] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs3] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs4] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs5] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs6] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs7] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs8] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToParams9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs9] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args9] },
    };
    #endregion
}
