// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestDataHolders.Named.Interfaces;

public interface INamedRows<TRow>
{
    IEnumerable<TRow>? GetNamedRows(string? testMethodName);
    IEnumerable<TRow>? GetNamedRows(string? testMethodName, ArgsCode? argsCode);
}
