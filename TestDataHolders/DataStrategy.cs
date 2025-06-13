// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

public sealed record DataStrategy<TTestData>(
    ArgsCode ArgsCode,
    bool? WithExpected)
: IDataStrategy
where TTestData : notnull, ITestData
{
    public static bool? GetWithExpected(Type expectedResultType)
    => typeof(TTestData).GetInterface(expectedResultType.Name) != null;
}