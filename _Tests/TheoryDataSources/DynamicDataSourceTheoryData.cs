// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.Tests.TheoryDataSources;

public class DynamicDataSourceTheoryData
{
    public static TheoryData<string, object> GetTestDisplayNameNullOrEmptyArgsTheoryData => new()
    {
        { null, null },
        { null, ActualResult },
        { string.Empty, null },
        { TestMethodName, null },
        { TestMethodName, null },
        { TestMethodName, Array.Empty<object>() },
        { TestMethodName, new DummyStruct() }, // ToString() == null;
        { TestMethodName, string.Empty },
    };
    public static TheoryData<ArgsCode, ArgsCode?, Func<object[]>, object[]> OtionalToArgsTheoryData => new()
    {
        #region TestDataToArgs
        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [.. TestDataArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1), [TestDataArgs1] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [.. TestDataArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2), [TestDataArgs2] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [.. TestDataArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3), [TestDataArgs3] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [.. TestDataArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4), [TestDataArgs4] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataArgs5] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5),  [TestDataArgs5] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataArgs5] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataArgs6] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataArgs7] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataArgs8] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataToArgs(ActualDefinition, ExpectedString, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataArgs9] },
        #endregion

        #region TestDataReturnsToArgs
        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [.. TestDataReturnsArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1), [TestDataReturnsArgs1] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [.. TestDataReturnsArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2), [TestDataReturnsArgs2] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [.. TestDataReturnsArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3), [TestDataReturnsArgs3] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [.. TestDataReturnsArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4), [TestDataReturnsArgs4] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataReturnsArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataReturnsArgs5] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataReturnsArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataReturnsArgs6] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataReturnsArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataReturnsArgs7] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataReturnsArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataReturnsArgs8] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataReturnsArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataReturnsToArgs(ActualDefinition, DummyEnumTestValue, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataReturnsArgs9] },
        #endregion

        #region TestDataThrowsToArgs
        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [.. TestDataThrowsArgs0, Arg1] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1), [TestDataThrowsArgs1] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [.. TestDataThrowsArgs0, .. Args2] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2), [TestDataThrowsArgs2] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [.. TestDataThrowsArgs0, .. Args3] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3), [TestDataThrowsArgs3] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [.. TestDataThrowsArgs0, .. Args4] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4), [TestDataThrowsArgs4] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [.. TestDataThrowsArgs0, .. Args5] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5), [TestDataThrowsArgs5] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [.. TestDataThrowsArgs0, .. Args6] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6), [TestDataThrowsArgs6] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [.. TestDataThrowsArgs0, .. Args7] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7), [TestDataThrowsArgs7] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [.. TestDataThrowsArgs0, .. Args8] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8), [TestDataThrowsArgs8] },

        { ArgsCode.Instance, null, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
        { ArgsCode.Properties, null, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Properties, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
        { ArgsCode.Properties, ArgsCode.Properties, () => new DynamicDataSourceChild(ArgsCode.Properties).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [.. TestDataThrowsArgs0, .. Args9] },
        { ArgsCode.Instance, ArgsCode.Instance, () => new DynamicDataSourceChild(ArgsCode.Instance).TestDataThrowsToArgs(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9), [TestDataThrowsArgs9] },
        #endregion
    };

    public static TheoryData<ArgsCode, ArgsCode?, ArgsCode> ArgsCodesTheoryData => new()
    {
        { ArgsCode.Instance, null, ArgsCode.Instance },
        { ArgsCode.Properties, null, ArgsCode.Properties },
        { ArgsCode.Instance, ArgsCode.Properties, ArgsCode.Properties },
        { ArgsCode.Properties, ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Instance, ArgsCode.Instance, ArgsCode.Instance },
        { ArgsCode.Properties, ArgsCode.Properties, ArgsCode.Properties },
    };

    #region TestDataToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs1] },
        { ArgsCode.Properties, [.. TestDataArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs2] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs3] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs4] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs5] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs6] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs7] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs8] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataArgs9] },
        { ArgsCode.Properties, [.. TestDataArgs0, .. Args9] },
    };
    #endregion

    #region TestDataReturnsToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs1] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs2] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs3] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs4] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs5] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs6] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs7] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs8] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataReturnsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataReturnsArgs9] },
        { ArgsCode.Properties, [.. TestDataReturnsArgs0, .. Args9] },
    };
    #endregion

    #region TestDataThrowsToArgs data sources
    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs1ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs1] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, Arg1] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs2ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs2] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args2] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs3ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs3] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args3] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs4ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs4] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args4] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs5ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs5] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args5] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs6ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs6] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args6] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs7ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs7] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args7] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs8ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs8] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args8] },
    };

    public static TheoryData<ArgsCode, object[]> TestDataThrowsToArgs9ArgsTheoryData => new()
    {
        { ArgsCode.Instance, [TestDataThrowsArgs9] },
        { ArgsCode.Properties, [.. TestDataThrowsArgs0, .. Args9] },
    };
    #endregion
}
