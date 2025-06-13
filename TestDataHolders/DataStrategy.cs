// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

public sealed class DataStrategy(
    ArgsCode argsCode,
    bool? withExpected)
: IDataStrategy
{
    public ArgsCode ArgsCode { get; init; } = argsCode;
    public bool? WithExpected { get; init; } = withExpected;
}
