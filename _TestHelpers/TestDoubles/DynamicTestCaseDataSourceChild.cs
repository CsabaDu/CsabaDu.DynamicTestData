// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.NUnit.DynamicDataSources;

namespace CsabaDu.DynamicTestData.TestHelpers.TestDoubles;

public class DynamicTestCaseDataSourceChild(ArgsCode argsCode)
: DynamicTestCaseDataSource(argsCode);
