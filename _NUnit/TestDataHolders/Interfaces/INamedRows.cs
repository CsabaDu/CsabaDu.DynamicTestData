// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface INamedRows
{
    IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName);
    IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName, ArgsCode? argsCode);
}