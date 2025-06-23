// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders;

public sealed record DataStrategy(
    ArgsCode ArgsCode,
    bool? WithExpected)
: DataStrategyBase(ArgsCode.Defined(nameof(ArgsCode))),
IDataStrategy
{
    public bool Equals(IDataStrategy? other)
    => other is not null &&
        ArgsCode == other.ArgsCode &&
        WithExpected == other.WithExpected;
}
