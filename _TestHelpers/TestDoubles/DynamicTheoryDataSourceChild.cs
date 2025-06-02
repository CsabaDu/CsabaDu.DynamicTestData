// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using Xunit;

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public class DynamicTheoryDataSourceChild(ArgsCode argsCode)
: DynamicDataSource(argsCode)
{
    internal ArgsCode GetArgsCode() => ArgsCode;

    //internal TheoryData? GetTheoryData() => TheoryData;

    //internal void SetArgsCodeWithInvalidValue() => typeof(DynamicDataSource)
    //    .GetField(ArgsCodeName, BindingFlags.NonPublic | BindingFlags.Instance)
    //    ?.SetValue(this, InvalidArgsCode);
}
