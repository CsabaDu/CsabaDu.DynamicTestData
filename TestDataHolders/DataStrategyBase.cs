// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders;

public abstract record DataStrategyBase(ArgsCode ArgsCode)
: IArgsCode;
