// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTestDataXunitSource(ArgsCode argsCode)
: DynamicDataSource(argsCode, typeof(IExpected));
