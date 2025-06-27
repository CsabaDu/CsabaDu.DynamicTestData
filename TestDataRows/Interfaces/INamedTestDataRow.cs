// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataRows.Interfaces;

//public interface INamedTestDataRow;

public interface INamedTestDataRow<TRow>
: ITestDataRow<TRow>
{
    TRow Convert(IDataStrategy dataStrategy, string? testMethodName);
}
