// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

public abstract class DynamicNunitDataSource(ArgsCode argsCode)
: DynamicObjectArraySource(argsCode, typeof(ITestDataReturns));
