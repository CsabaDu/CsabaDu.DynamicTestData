// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.TestDataHolders.Named.Interfaces;

public interface INamedTestDataRow<TRow>
: ITestDataRow<TRow>
{
    TRow Convert(IDataStrategy dataStrategy, string? testMethodName);
}
