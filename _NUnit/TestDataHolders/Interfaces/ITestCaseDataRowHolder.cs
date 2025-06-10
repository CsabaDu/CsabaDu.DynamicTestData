// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using NUnit.Framework.Interfaces;

namespace CsabaDu.DynamicTestData.NUnit.TestDataHolders.Interfaces;

public interface ITestCaseDataRowHolder
: IDataRowHolder<TestCaseData>
{
    IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName);
    IEnumerable<TestCaseData>? GetNamedRows(string? testMethodName, ArgsCode? argsCode);
}
