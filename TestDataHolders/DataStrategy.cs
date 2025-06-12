// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders;

public sealed record DataStrategy<TTestData>(
    ArgsCode ArgsCode,
    bool? WithExpected)
: IDataStrategy
where TTestData : notnull, ITestData
{
    public static IDataStrategy Default
    => new DataStrategy<TTestData>(default, null);

    public static bool? GetWithExpected(
        IDataStrategy? dataStrategy,
        string? expectedTypeName)
    => dataStrategy == null ?
        typeof(TTestData).GetInterface(expectedTypeName ?? string.Empty) != null
        : dataStrategy.WithExpected;

    public static bool? GetWithExpected(
        string? expectedTypeName)
    =>  GetWithExpected(null, expectedTypeName);

}