// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DynamicDataSources;

public abstract class DynamicExpectedDataSource(ArgsCode argsCode)
: DynamicDataSource(argsCode, typeof(IExpected));