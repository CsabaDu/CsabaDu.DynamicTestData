// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.DataRowHolders.Interfaces;

public interface ITestDataRows
{
    IEnumerable<ITestDataRow>? GetTestDataRows(ArgsCode? argsCode);
    IDataStrategy GetDataStrategy(ArgsCode? argsCode);
}
